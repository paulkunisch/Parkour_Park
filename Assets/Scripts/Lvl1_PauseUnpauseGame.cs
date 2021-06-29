using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Author: David Hasenhüttl/20.05.2021
public class Lvl1_PauseUnpauseGame : MonoBehaviour
{
    public GameObject pauseMenu; // select a canvas holding your pause menu
    public GameObject character; // here we selected a parent GO named "characterposition" which holds all the respective character prefabs (to turn on/off in between pause screen)
    public GameObject hud;       // disable HUD messages ("go to the king", ...)
    public GameObject MenuFirstButton; // enable controller support, select a button in your pause menu canvas

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Pause")) //Escape or Gamepad(Start)
        {
            PauseUnpause();// execute function
        }
    }
    
    public void PauseUnpause()
    {
        if (!pauseMenu.activeInHierarchy) // Pause is not activated --> activate
        {
            if (pauseMenu.scene.IsValid()) { pauseMenu.SetActive(true); } // ui with pause elements
            if (character.scene.IsValid()) { character.SetActive(false); } // character controller deactivated, so you dont move in pause screen
            if (hud.scene.IsValid()) { hud.SetActive(false); } // hud deactivated in pause
            Time.timeScale = 0f;
            // clear selected Object
            EventSystem.current.SetSelectedGameObject(null);
            // set a new selected Object
            EventSystem.current.SetSelectedGameObject(MenuFirstButton);
        } 
        else // leave pause
        {
            if (pauseMenu.scene.IsValid()) { pauseMenu.SetActive(false); }
            if (character.scene.IsValid()) { character.SetActive(true); }
            if (hud.scene.IsValid()) { hud.SetActive(true); }
            Time.timeScale = 1f;
            if (pauseMenu.scene.IsValid()) { pauseMenu.SetActive(false); } // unity being unity
        }
    }
}
