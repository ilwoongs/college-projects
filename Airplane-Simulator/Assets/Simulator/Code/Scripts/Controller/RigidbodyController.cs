using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyController : MonoBehaviour
{
    protected Rigidbody rb;
    protected AudioSource aud;

    // Start is called before the first frame update
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        aud = GetComponent<AudioSource>();
        if (aud)
            aud.playOnAwake=false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb)
            HandlePhysics();
    }

    protected virtual void HandlePhysics() { }
}
