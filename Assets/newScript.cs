using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string whichScene;

    private void OnMouseDown()
    {
        if (whichScene != "")
        {
            Debug.LogWarning("Button pressed: change Scene > " + whichScene);
            SceneManager.LoadScene(whichScene);
        }
        else
            Debug.LogError("DMTButtonScene: no Scene Name specified!");
    }
}