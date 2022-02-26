using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XrayVisionSound : MonoBehaviour
{
    AudioSource audioSource;
    bool audioPlaying;
    Slider xraySlider;
    void Start()
    {
        xraySlider = GameObject.Find("XrayBar").transform.GetChild(0).GetComponent<Slider>();
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("m") && !audioPlaying && xraySlider.value > 0)
        {
            audioSource.Play();
            audioPlaying = true;
        }else if(Input.GetKeyUp("m") || xraySlider.value == 0)
        {
            audioSource.Stop();
            audioPlaying = false;
        }
    }
}
