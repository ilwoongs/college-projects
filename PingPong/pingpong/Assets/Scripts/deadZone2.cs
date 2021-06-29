using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deadZone2 : MonoBehaviour
{
    public GameObject ball;
    public Text player1;
    Vector3 resetPos;

    private AudioSource audi;
    private void Start()
    {
        audi = GetComponent<AudioSource>();
        resetPos = new Vector3(0, 0, 0);
    }
    private void OnTriggerEnter(Collider collider)
    {
        audi.Play();
        GM.instance.score1 += 1;
        player1.text = GM.instance.score1.ToString();
        ball.transform.position = resetPos;

        GM.instance.CheckGameOver(ball);
    }
}
