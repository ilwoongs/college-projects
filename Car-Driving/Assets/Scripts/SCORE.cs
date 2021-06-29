using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCORE : MonoBehaviour
{
    public TextMesh scoreText;
    public static SCORE instance = null;
    public int score1 = 100;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        scoreText.text = "Score: " + score1;
    }
    private void OnTriggerEnter(Collider other)
    {
        score1 -= 1;
        scoreText.text = "Score: " + score1;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            score1 -= 20;
            scoreText.text = "Score: " + score1;
        }
    }

}
