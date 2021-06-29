using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    public float maxForce = 200f;
    public float maxRPM = 2550f;


    public Propeller propeller;

    public Vector3 CalcForce(float throttle)
    {
        float finalThrottle = Mathf.Clamp01(throttle);

        //propeller
        float currentRPM = finalThrottle * maxRPM;
        if (propeller)
        {
            propeller.HandlePropeller(currentRPM);
        }
        
        float finalPower = finalThrottle * maxForce;
        Vector3 finalForce = transform.forward * finalPower;
        
        return finalForce;
    }
}
