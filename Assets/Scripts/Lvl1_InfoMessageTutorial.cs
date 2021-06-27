using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lvl1_InfoMessageTutorial : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject character;
    public GameObject hud;
    public GameObject MenuFirstButton;
    [SerializeField]
    private bool disableTutorial = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && (PlayerPrefs.GetInt("TutorialDisable") != 1))
        {
            if (disableTutorial == true) PlayerPrefs.SetInt("TutorialDisable", 1);

            PauseUnpause();
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