using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: David Hasenhüttl
// totally not working!
// that was a try to implement continoous music across menu scenes?
// if needed, try to set the same track on the menu scenes and try
// to save the current progressed time via playerprefs(seconds played)
public class General_PlayGlobalMusic : MonoBehaviour
{ 
    private AudioSource _audioSource;
    private GameObject[] other;
    private bool NotFirst = false;
    private void Awake()
    {
        other = GameObject.FindGameObjectsWithTag("Music");

        foreach (GameObject oneOther in other)
        {
            if (oneOther.scene.buildIndex == -1)
            {
                NotFirst = true;
            }
        }

        if (NotFirst == true)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}