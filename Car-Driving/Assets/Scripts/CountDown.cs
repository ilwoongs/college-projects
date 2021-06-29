using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CountDown : MonoBehaviour
{

    public GameObject three;
    public GameObject two;
    public GameObject one;
    private float number = 4.0f;



    private void Start()
    {
        three.SetActive(false);
        two.SetActive(false);
        one.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        number -= Time.deltaTime;
        if (number <=3.0f && number > 2.0f)
        {
            three.SetActive(true);
        }
        else if(number <=2.0f && number > 1.0f)
        {
            three.SetActive(false);
            two.SetActive(true);
        }
        else if(number <=1.0f && number > 0.0f)
        {
            two.SetActive(false);
            one.SetActive(true);
        }
        else if (number <= 0.0f)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

}
