using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule : MonoBehaviour
{

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject button6;

    // Start is called before the first frame update
    public void buttonClicked()
    {
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);

        button4.SetActive(true);
        button5.SetActive(true);
        button6.SetActive(true);
    }
}
