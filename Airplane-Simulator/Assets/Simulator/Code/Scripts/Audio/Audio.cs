using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AirplaneInput input;
    public AudioSource idle;
    public AudioSource full;

    private float finalVolume;
    // Start is called before the first frame update
    void Start()
    {
        if (full)
        {
            full.volume = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (input)
        {
            HandleAudio();
        }
    }

    protected virtual void HandleAudio()
    {
        finalVolume = Mathf.Lerp(0f, 0.5f, input.StickyThrottle);

        if (full)
        {
            full.volume = finalVolume;
        }
    }
}
