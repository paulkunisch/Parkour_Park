using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// Author: David Hasenhüttl
public class OptionMenu : MonoBehaviour // this script handles the audio of the game through a slider in the option menu
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
