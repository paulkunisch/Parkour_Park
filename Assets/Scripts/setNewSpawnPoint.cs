using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("deathzone", deathzoneY);
        PlayerPrefs.SetInt("respawnPoint", respawn);

        uiMessage.SetActive(true);
        StartCoroutine(LateCall());
    }

    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(uiSecondsEnabled);

        uiMessage.SetActive(false);
    }

}