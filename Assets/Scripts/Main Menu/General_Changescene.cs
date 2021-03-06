using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Author: Alexander Nischelwitzer
public class General_Changescene : MonoBehaviour
{


    void Start()
    {
        Debug.Log("DMTButtonScene Management loaded");
    }

    void Update()
    {

    }

    public void DMT_GoScene(string whichScene)
    {
        if (whichScene != "")
        {
            Debug.Log("DMTButtonScene: SceneManagement go to > " + whichScene);
            SceneManager.LoadScene(whichScene);
        }
        else
            Debug.LogError("DMTButtonScene: no Scene Name specified!");
    }

    public void DMT_QuitApp()
    {
        Debug.LogWarning("Quit Button pressed: quit application!");
        Application.Quit();
    }

}