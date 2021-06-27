using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

// Author: David Hasenhüttl
public class Menu_Controller_Navigation : MonoBehaviour 
{
    // this script is used to leave multiplayer with escape-button or start(gamepad)

    public string whichScene;               // choose szene to go to with a string
    public GameObject mainMenuFirstButton;  // enable controller support, select button
    private InputMaster myinputs;           // new Input System

    private void Awake()
    {
        myinputs = new InputMaster();
        myinputs.UI.Esc.performed += x => Escape();
    }

    private void Start()
    {
        // clear selected Object
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selected Object
        EventSystem.current.SetSelectedGameObject(mainMenuFirstButton);

        if (SceneManager.GetActiveScene().name == "MainMenu") // set boost back to default once entering the MainMenu
        {
            PlayerPrefs.SetInt("boost", 0);
        }
    }

    private void OnEnable()
    {
        myinputs.Enable();
    }

    private void OnDisable()
    {
        myinputs.Disable();
    }

    private void Escape() // go to scene on esc or start(gamepad) pressed
    {
            {
                Debug.Log("DMTButtonScene: SceneManagement go to > " + whichScene);
                SceneManager.LoadScene(whichScene);
            }
        }
}
