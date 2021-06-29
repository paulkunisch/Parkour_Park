using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: David Hasenhüttl/20.06.2021
public class setNewSpawnPoint : MonoBehaviour
{
    [SerializeField]
    private int respawn = 1;
    [SerializeField]
    private int deathzoneY = 0;
    [SerializeField]
    private GameObject uiMessage;
    [SerializeField]
    private int uiSecondsEnabled = 5;
   
       // used for multiplayer, setting variables for next respawn
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("deathzone", deathzoneY);
            PlayerPrefs.SetInt("respawnPoint", respawn);

            uiMessage.SetActive(true);
            StartCoroutine(LateCall());
           
        }
        
        
    }

    IEnumerator LateCall() // hyperthreaded wait
    {
        yield return new WaitForSeconds(uiSecondsEnabled);

        uiMessage.SetActive(false);
    }
   

}