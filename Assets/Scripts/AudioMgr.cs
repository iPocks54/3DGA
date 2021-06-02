using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMgr : MonoBehaviour
{
    public static AudioMgr Instance;

    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        audio = this.GetComponent<AudioSource>();


    }


    public void SetAudio(float voice)
    {
        audio.volume = voice;
    }

    public void SetAudio(bool isOn)
    {
        if (isOn)
        {
            audio.Play();
        }
        else
        {
            audio.Pause();
        }
       
    }
}
