using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{    //Degrees per second = (RPM * 360) / 60

    public void HandlePropeller(float currentRPM)
    {
        //propeller spinning y-axis (Vector3.up)
        float dps = ((currentRPM * 360f) / 60f) * Time.deltaTime;
        transform.Rotate(Vector3.up,dps);
    }
}
