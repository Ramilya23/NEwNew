using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class button : MonoBehaviour
{
    public AudioMixer audioMixer;
    public string volumeCategory1 = "button";
    public Slider slider;

    void Start()
    {
        float currentVolume;

        audioMixer.GetFloat(volumeCategory1, out currentVolume);
        slider.value = Mathf.Pow(10, currentVolume / 20);
        slider.onValueChanged.AddListener(SetVolume);

    }

    private void SetVolume(float volume)
    {
        float volumeInDB = Mathf.Log10(volume) * 20;

        if (volume <= 0)
        {
            volumeInDB = -80;
        }

        audioMixer.SetFloat(volumeCategory1, volumeInDB);
    }

}