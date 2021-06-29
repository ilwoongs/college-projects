using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneContoller : RigidbodyController
{
    public AirplaneInput input;
    public Characteristics characteristics;
    public Transform centerOfGravity;
    public GameObject groundCam1;
    public GameObject groundCam2;

    public GameObject controlKeyText;


    public float airplaneweight = 800f;

    [Header("Cameras")]
    public List<Camera> cameras = new List<Camera>();

    [Header("Engines")]
    public List<Engine> engines = new List<Engine>();

    [Header("Wheels")]
    public List<Wheel> wheels = new List<Wheel>();

    [Header("Control Surfaces")]
    public List<ControlSurfaces> controlSurfaces = new List<ControlSurfaces>();

    
    const float lbToKg = 0.453592f;
    private int cameraInd=0;

    public override void Start()
    {
        base.Start();

        float massInKg = airplaneweight * lbToKg;
        if(rb)
        {
            rb.mass = massInKg;
            if(centerOfGravity)
            {
                rb.centerOfMass = centerOfGravity.localPosition;
            }

            characteristics = GetComponent<Characteristics>();
            if (characteristics)
            {
                characteristics.InitCharacteristics(rb,input);

            }
        }

        if(wheels != null)
        {
            if(wheels.Count > 0)
            {
                foreach(Wheel wheel in wheels)
                {
                    wheel.InitWheel();
                }
            }
        }

        



    }
    
    void Update()
    {
        CameraSwitch();
    }
    void CameraSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Z)){
            cameraInd++;
            controlKeyText.SetActive(false);
            if (cameraInd > 4)
            {
                foreach (Camera cam in cameras)
                {
                    cam.enabled = false;
                }
                cameraInd = 0;
                controlKeyText.SetActive(true);
            }
            cameras[cameraInd].enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            cameras[cameraInd].enabled = false;
            controlKeyText.SetActive(false);
            groundCam1.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            cameras[cameraInd].enabled = true;
            controlKeyText.SetActive(true);
            groundCam1.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            cameras[cameraInd].enabled = false;
            controlKeyText.SetActive(false);
            groundCam2.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            cameras[cameraInd].enabled = true;
            controlKeyText.SetActive(true);
            groundCam2.SetActive(false);
        }
    }
    protected override void HandlePhysics()
    {
        base.HandlePhysics();

        if (input)
        {
            HandleEngines();
            HandleCharacteristics();
            HandleControlSurfaces();
            HandleWheel();
        }
        
    }

    void HandleEngines()
    {
        if(engines != null)
        {
            if(engines.Count > 0)
            {
                foreach(Engine engine in engines)
                {
                    rb.AddForce(engine.CalcForce(input.StickyThrottle));
                }
            }
        }
    }
    void HandleCharacteristics()
    {
        if (characteristics)
        {
            characteristics.UpdateCharacteristics();
        }
    }

    void HandleControlSurfaces()
    {
        if(controlSurfaces.Count > 0)
        {
            foreach(ControlSurfaces controlSurface in controlSurfaces)
            {
                controlSurface.HandleControlSurface(input);
            }
        }

    }
    void HandleWheel()
    {
        if (wheels.Count > 0)
        {
            foreach (Wheel wheel in wheels)
            {
                wheel.HandleWheel(input);
            }
        }
    }





}
