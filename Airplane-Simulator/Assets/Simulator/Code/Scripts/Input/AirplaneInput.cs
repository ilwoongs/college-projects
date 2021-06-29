using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AirplaneInput : MonoBehaviour
{
    public float throttleSpeed = 0.1f;
    private float stickyThrottle;
    public float StickyThrottle
    {
        get
        {
            return stickyThrottle;
        }
    }

        public float pitch = 0.0f;
        public float roll = 0.0f;
        public float yaw = 0.0f;
        public float throttle = 0.0f;
        public int flaps = 1;

    protected float brake = 0.0f;


    // Start is called before the first frame update
    void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            HandleInput();
        }

        void HandleInput()
        {
            pitch = Input.GetAxis("Vertical");
            roll = Input.GetAxis("Horizontal");
            yaw = Input.GetAxis("Yaw");
            throttle = Input.GetAxis("Throttle");
        StickyThrottleControl();
          



        }

    void StickyThrottleControl()
    {
        stickyThrottle = stickyThrottle + (throttle * throttleSpeed * Time.deltaTime);
        stickyThrottle = Mathf.Clamp01(stickyThrottle);
    }
}
