using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleController : MonoBehaviour
{

    public float paddleSpeed = 0.5f;
    private AudioSource audio1;

    private Vector3 pos1 = new Vector3(-9f, 0, 0);

    private void Start()
    {
        audio1 = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        float yPos = transform.position.y + (Input.GetAxis("Vertical2") * paddleSpeed);
        pos1 = new Vector3(-9f, Mathf.Clamp(yPos, -4f, 4f), 0);
        transform.position = pos1;        
    }
    private void OnCollisionEnter(Collision collision)
    {
        audio1.Play();
    }
}
