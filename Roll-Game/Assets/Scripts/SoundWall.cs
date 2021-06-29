using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWall : MonoBehaviour
{
    private AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent <AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        aud.Play();
    }
}
