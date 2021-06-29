using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{

    public GameObject plane;
    public GameObject congText;
    public GameObject controllText;
    void OnTriggerEnter(Collider collider)
    {

        plane.SetActive(false);
        congText.SetActive(true);
        controllText.SetActive(false);

    }
}
