using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider frontLW, frontRW;
    public WheelCollider backLW, backRW;
    public Transform frontLT, frontRT;
    public Transform backLT, backRT;
    public TextMesh textWhenFlips;

    public float maxSteering = 30.0f;
    public float carSpeed = 50.0f;

    private float horizontalInput;
    private float verticalInput;
    private float steeringAngle;


    Quaternion initial;

    private void Start()
    {
        initial = transform.rotation;
    }
    public void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

    }

    private void Steer()
    {
        steeringAngle = maxSteering * horizontalInput;
        frontLW.steerAngle = steeringAngle;
        frontRW.steerAngle = steeringAngle;

    }

    private void Accel()
    {
        frontLW.motorTorque = verticalInput * carSpeed;
        frontRW.motorTorque = verticalInput * carSpeed;
    }

    private void UpdateWheelPoses()
    {
        //Wheel rotation
        UpdateWheelPos(frontLW, frontLT);
        UpdateWheelPos(frontRW, frontRT);
        UpdateWheelPos(backLW, backLT);
        UpdateWheelPos(backRW, backRT);
    }

    private void UpdateWheelPos(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _rot = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _rot);
        _transform.position = _pos;
        _transform.rotation = _rot;
    }

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accel();
        UpdateWheelPoses();


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.rotation = initial;
        }
    }
}
