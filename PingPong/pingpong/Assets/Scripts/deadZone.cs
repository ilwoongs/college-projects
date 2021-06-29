using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deadZone : MonoBehaviour
{
    public GameObject ball;
    public Text player2;
    Vector3 resetPos;
    private AudioSource audi;

    private void Start()
    {
        audi = GetComponent<AudioSource>();
        resetPos = new Vector3(0,0,0);
    }
    private void OnTriggerEnter(Collider collider)
    {
        audi.Play();
        GM.instance.score2 += 1;
        player2.text = GM.instance.score2.ToString();
        ball.transform.position = resetPos;

        GM.instance.CheckGameOver(ball);

    }
}
