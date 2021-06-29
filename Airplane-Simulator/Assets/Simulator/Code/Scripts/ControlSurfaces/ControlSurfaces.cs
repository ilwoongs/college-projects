using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ControlSurfaceType
{
    Rudder,
    Elevator,
    Flap,
    LAileron,
    RAileron
}

public class ControlSurfaces : MonoBehaviour
{
    public ControlSurfaceType type = ControlSurfaceType.Elevator;
    public float maxAngle = 30f;
    public Transform controlSurfaceGraphic;
    public float smoothSpeed = 4;
    public AirplaneInput inputControl;

    private float finalAngle=0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (controlSurfaceGraphic)
        {
            HandleControlSurface(inputControl);

            if (type == ControlSurfaceType.Elevator)
            {
                controlSurfaceGraphic.localRotation = Quaternion.Euler(finalAngle - 90, 0, 0);
                Debug.Log(controlSurfaceGraphic.localRotation);
            }
            else if (type == ControlSurfaceType.Rudder)
            {
                controlSurfaceGraphic.localRotation = Quaternion.Euler(-90, -finalAngle, 0);
            }
            else if (type == ControlSurfaceType.RAileron)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    controlSurfaceGraphic.Rotate(30, 0, 0, Space.Self);
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    controlSurfaceGraphic.Rotate(-30, 0, 0, Space.Self);
                }

                if (Input.GetKeyUp(KeyCode.D))
                {
                    controlSurfaceGraphic.Rotate(-30, 0, 0, Space.Self);
                }
                else if (Input.GetKeyUp(KeyCode.A))
                {
                    controlSurfaceGraphic.Rotate(30, 0, 0, Space.Self);
                }
            }
            else if (type == ControlSurfaceType.LAileron)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    controlSurfaceGraphic.Rotate(30, 0, 0, Space.Self);
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    controlSurfaceGraphic.Rotate(-30, 0, 0, Space.Self);
                }
                if (Input.GetKeyUp(KeyCode.D))
                {
                    controlSurfaceGraphic.Rotate(30, 0, 0, Space.Self);
                }
                else if (Input.GetKeyUp(KeyCode.A))
                {
                    controlSurfaceGraphic.Rotate(-30, 0, 0, Space.Self);
                }
            }
            else if (type == ControlSurfaceType.Flap)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    controlSurfaceGraphic.Rotate(-5, 0, 0, Space.Self);
                }
                else if (Input.GetKeyDown(KeyCode.E))
                {
                    controlSurfaceGraphic.Rotate(5, 0, 0, Space.Self);
                }

            }
        }

        }
        
    

    public void HandleControlSurface(AirplaneInput input)
    {
        float inputValue = 0f;
        switch (type) {
            case ControlSurfaceType.Rudder:
                inputValue = input.yaw;
                break;
            case ControlSurfaceType.Elevator:
                inputValue = input.pitch;
                break;
            case ControlSurfaceType.Flap:
                inputValue = input.flaps;
                break;
            case ControlSurfaceType.LAileron:
            case ControlSurfaceType.RAileron:
                inputValue = input.roll;
                break;
            default:
                break;
        }
        finalAngle = maxAngle * inputValue;
    }
}




