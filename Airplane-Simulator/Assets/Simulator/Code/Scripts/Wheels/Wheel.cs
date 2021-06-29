using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public Transform WheelGraphic;
    private WheelCollider WheelCol;
    private Vector3 pos;
    private Quaternion rot;

    void Start()
    {
        WheelCol = GetComponent<WheelCollider>();
    }
    // Start is called before the first frame update
    public void InitWheel()
    {
        if (WheelCol)
        {
            WheelCol.motorTorque = 0.0000000000001f;
        }
    }

    public void HandleWheel(AirplaneInput input) {
        if (WheelCol)
        {
            WheelCol.GetWorldPose(out pos, out rot);
            if (WheelGraphic)
            {
                WheelGraphic.position = pos;
                WheelGraphic.rotation = rot;
            }
        }

        
    }
}
