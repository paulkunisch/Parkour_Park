using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1_PauseUnpauseGame : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject character;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Pause"))
        {
            PauseUnpause();
        }
    }
    
    public void PauseUnpause()
    {
        if (!pauseMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(true);
            character.SetActive(false);
            Time.timeScale = 0f;
        } else
        {
            pauseMenu.SetActive(false);
            character.SetActive(true);
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }
    }
}
