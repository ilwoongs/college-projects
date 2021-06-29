using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform objectToFollow;
    public Vector3 offset;
    public float followSpeed = 10;
    public float lockSpeed = 10;

    public void target()
    {
        Vector3 direction = objectToFollow.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, lockSpeed * Time.deltaTime);
    }

    public void MoveToTarget()
    {
        Vector3 targetPos = objectToFollow.position +
                            objectToFollow.forward * offset.z +
                            objectToFollow.right * offset.x +
                            objectToFollow.up * offset.y;
        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
    }

    public void FixedUpdate()
    {
        target();
        MoveToTarget();
    }
}
