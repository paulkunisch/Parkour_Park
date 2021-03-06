using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: David Hasenhüttl/14.06.2021
public class Menu_Tutorial_HUD_enable_disable : MonoBehaviour // this script handles the turn on/shut down of Tutorial elements using triggerActions
{
    [SerializeField]
    private GameObject triggerEnterEnable;
    [SerializeField]
    private GameObject triggerEnterDisable;
    [SerializeField]
    private GameObject triggerExitEnable;
    [SerializeField]
    private GameObject triggerExitDisable;


    private void Start()
    {
        PlayerPrefs.SetInt("TutorialDisable", 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && (PlayerPrefs.GetInt("TutorialDisable") != 1))
        {
            if (triggerEnterEnable != null) triggerEnterEnable.SetActive(true);
            if (triggerEnterDisable != null) triggerEnterDisable.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (triggerExitEnable != null) triggerExitEnable.SetActive(true);
            if (triggerExitDisable != null) triggerExitDisable.SetActive(false);
        }
    }
}
