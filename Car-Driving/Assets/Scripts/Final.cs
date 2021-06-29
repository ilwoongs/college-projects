using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject button1;
    public GameObject button2;
    public GameObject wins;
    public GameObject loses;

    public GameObject others;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
  
  
    private void OnTriggerEnter(Collider other)
    {
        text1.SetActive(false);
        text2.SetActive(false);
        button1.SetActive(true);
        button2.SetActive(true);

        if (SCORE.instance.score1 >= 15 && SCORE.instance.score1<=100)
            wins.SetActive(true);
        else
            loses.SetActive(true);

        others.SetActive(false);



    }
}
