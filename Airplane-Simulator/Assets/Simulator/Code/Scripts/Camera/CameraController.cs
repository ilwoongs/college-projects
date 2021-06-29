using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float distance = 0f;
    public float height = 0f;

    void FixedUpdate()
    {
        if (target)
        {
            HandleCamera();
        }
    }
    void HandleCamera()
    {
        Vector3 newPosition = target.position + (-target.forward * distance) + (Vector3.up * height);
        transform.position = newPosition;
        transform.LookAt(target);
    }
}
