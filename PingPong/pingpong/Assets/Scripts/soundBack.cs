using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundBack : MonoBehaviour
{
    private AudioSource audi;
    // Start is called before the first frame update
    void Start()
    {
        audi = GetComponent<AudioSource>();
        audi.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
