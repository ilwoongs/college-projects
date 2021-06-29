using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public Text score;
    public float ballSpeed = 20.0f;
    public TextMesh Result;
    public GameObject scoreObject;
    public GameObject backblocks;
    public GameObject ball;
    public GameObject buttons;

    private AudioSource aud;
    private Rigidbody rb;
    private int count;
    private int blocks;
    private int remaining;
    

    private void Start()
    {
        aud = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        blocks = 8;
        count = 0;
        remaining = 12;
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement*ballSpeed);

    }

    private void OnTriggerEnter(Collider other)
    {
        aud.Play();
        if (other.gameObject.CompareTag("cube"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            blocks -= 1;
            remaining -= 1;

            score.text = "Score: " + count;
        }
        else if (other.gameObject.CompareTag("cylinder")) 
        {
            count += blocks;
            remaining -= 1;

            other.gameObject.SetActive(false);
            score.text = "Score: " + count;
        }

        if (remaining <= 0)
            ResultScore();
    }

    private void ResultScore()
    {
        backblocks.SetActive(false);
        scoreObject.SetActive(false);
        ball.SetActive(false);
        buttons.SetActive(true);
        if (count > 25)
            Result.text = "Player Won!\nScore: " + count;

        else
            Result.text = "Player Lost\nScore: " + count;

    }

}
