using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdvStart : MonoBehaviour
{
    public TextMesh count;
    public GameObject countObject;

    private float number = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        count.text = ((int)number).ToString();
        number -= Time.deltaTime;
        if (number <= 0.0f)
        {
            SceneManager.LoadScene("Advanced");
        }
    }
}
