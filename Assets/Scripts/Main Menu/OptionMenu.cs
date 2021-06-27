using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionMenu : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;


    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
    public void SetVolume(bool muted)
    {
        if (muted) audioMixer.SetFloat("Volume", -80);
        else audioMixer.SetFloat("Volume", 0);
    }
}
