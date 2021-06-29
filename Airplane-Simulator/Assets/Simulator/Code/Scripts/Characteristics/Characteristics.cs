using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characteristics : MonoBehaviour
{
    public float forwardSpeed;
    public float mph;
    public float maxLiftPower = 800f;
    public float maxMPH = 110f;
    public float dragFactor = 0.01f;
    public float rbLerpSpeed = 0.01f;

    public float pitchSpeed = 8000f;
    public float rollSpeed = 10000f;
    public float yawSpeed = 10000f;

    private float pitchAngle;
    private float rollAngle;
    private float angleOfAttack;
    private float normalMPH;
    private float mpsTomph = 2.23694f;
    private float maxMPS;
    Rigidbody rb;
    AirplaneInput input;
    float startDrag;
    float startAngularDrag;
    public void InitCharacteristics(Rigidbody rbIn, AirplaneInput inputIn)
    {
        input = inputIn;
        rb = rbIn;
        startDrag = rb.drag;
        startAngularDrag = rb.angularDrag;
        maxMPS = maxMPH / mpsTomph;
    }

    public void UpdateCharacteristics()
    {
        if (rb)
        {
            CalcFSpeed();
            CalcLift();
            CalcDrag();
            HandlePitch();
            HandleRoll();
            HandleYaw();
            HandleBanking();
            HandleRigidbody();
        }
    }

    void CalcFSpeed()
    {
        Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
        forwardSpeed = Mathf.Max(0f,localVelocity.z);
        forwardSpeed = Mathf.Clamp(forwardSpeed, 0f, maxMPS);
        
        mph = forwardSpeed * mpsTomph;
        mph = Mathf.Clamp(mph, 0f, maxMPH);

        normalMPH = Mathf.InverseLerp(0f, maxMPH, mph);

    }
    
    void CalcLift()
    {
        angleOfAttack = Vector3.Dot(rb.velocity.normalized, transform.forward);
        angleOfAttack *= angleOfAttack;

        Vector3 lift = transform.up;
        float liftPower = forwardSpeed * maxLiftPower;

        Vector3 finalLiftPower = lift * liftPower * angleOfAttack;
        rb.AddForce(finalLiftPower);
    }

    void CalcDrag()
    {
        float dragSpeed = forwardSpeed * dragFactor;
        float finalDragSpeed = startDrag + dragSpeed;

        rb.drag = finalDragSpeed;
        rb.angularDrag = startAngularDrag * forwardSpeed;
    }

    void HandleRigidbody()
    {
        if (rb.velocity.magnitude > 1f)
        {
            Vector3 updatedVelocity = Vector3.Lerp(rb.velocity, transform.forward * forwardSpeed, forwardSpeed * angleOfAttack * Time.deltaTime * rbLerpSpeed);
            rb.velocity = updatedVelocity;

            Quaternion updatedRotation = Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(rb.velocity.normalized, transform.up), Time.deltaTime * rbLerpSpeed);
            rb.MoveRotation(updatedRotation);
        }
    }

    void HandlePitch()
    {   //controls tails to go down or up so that nose can go up or down
        Vector3 flatForward = transform.forward;
        flatForward.y = 0f;
        flatForward = flatForward.normalized;
        pitchAngle = Vector3.Angle(flatForward, transform.forward); //angle between these two vectors

        Vector3 pitchTorque = -input.pitch * pitchSpeed * transform.right;
        rb.AddTorque(pitchTorque);
    }

    void HandleRoll()
    {   //controls wings to up and down to make turn
        Vector3 flatRight = transform.right;
        flatRight.y = 0f;
        flatRight = flatRight.normalized;

        rollAngle = Vector3.SignedAngle(transform.right, flatRight, transform.forward);
        Vector3 rollTorque = -input.roll * rollSpeed * transform.forward;
        rb.AddTorque(rollTorque);

    }

    void HandleYaw()
    {
        Vector3 yawTorque = input.yaw * yawSpeed * transform.up;
        rb.AddTorque(yawTorque);

    }

    void HandleBanking()
    {
        float bankSide = Mathf.InverseLerp(-90f, 90f, rollAngle);
        float bankAmount = Mathf.Lerp(-1f, 1f, bankSide);

        Vector3 bankTorque = bankAmount * rollSpeed * transform.up;
        rb.AddTorque(bankTorque);
    }
}
