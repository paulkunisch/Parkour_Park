using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class General_TriggerSwapSzene : MonoBehaviour
{
    [SerializeField] 
    private string whichScene;
    [SerializeField] 
    private GameObject UI_text;
    [SerializeField] 
    private bool noTutorial;

    private bool isin = false;

    public void Update()
    {
        if (isin == true) 
        {
            if (whichScene != "" && (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("nextLevel")) && (PlayerPrefs.GetInt("TutorialDisable") == 1 || noTutorial))
            {

                Debug.Log("DMTButtonScene: SceneManagement go to > " + whichScene);
                SceneManager.LoadScene(whichScene);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (PlayerPrefs.GetInt("TutorialDisable") == 1 || noTutorial)
        {
            UI_text.SetActive(true);
            isin = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        UI_text.SetActive(false);
        isin = false;
    }
}
