using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Menu_Controller_Navigation : MonoBehaviour
{
    public string whichScene;
    public GameObject mainMenuFirstButton;
    private InputMaster myinputs;

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
    }

    private void OnEnable()
    {
        myinputs.Enable();
    }

    private void OnDisable()
    {
        myinputs.Disable();
    }


    public void Update()
    {

    }

    private void Escape()
    {
            {
                Debug.Log("DMTButtonScene: SceneManagement go to > " + whichScene);
                SceneManager.LoadScene(whichScene);
            }
        }
}
