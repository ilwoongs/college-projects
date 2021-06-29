using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{

    public int score1=0;
    public int score2=0;

    public GameObject gameover;
    public GameObject restart;
    public GameObject quit;
    public Text gameoverT;

    public static GM instance = null;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void CheckGameOver(GameObject ball)
    {

        if(score1>=5)
        {
            ball.SetActive(false);
            gameoverT.text = "GAME OVER \nPLAYER1 WIN";
            gameover.SetActive(true);
            quit.SetActive(true);
            restart.SetActive(true);
        }
        else if (score2 >= 5)
        {
            ball.SetActive(false);
            gameoverT.text = "GAME OVER \nPLAYER2 WIN";
            gameover.SetActive(true);
            quit.SetActive(true);
            restart.SetActive(true);
        }
    }
}
