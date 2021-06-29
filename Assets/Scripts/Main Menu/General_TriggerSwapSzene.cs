using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Author: David Hasenhüttl 04.05.2021
// put this script on a trigger GO, once you enter the trigger & tutorial is finished,
// you'll get a message asking you to confirm a scene change
// press the button shown in the ui message and you go to the scene
public class General_TriggerSwapSzene : MonoBehaviour
{
    [SerializeField] 
    private string whichScene; // scene to go to
    [SerializeField] 
    private GameObject UI_text; // ui text "press space or gamepad(start) to change to the next level"
    [SerializeField] 
    private bool noTutorial; // if there is no tutorial in this level = select true

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
