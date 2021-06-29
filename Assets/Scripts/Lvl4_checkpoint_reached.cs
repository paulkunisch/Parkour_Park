using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: David Hasenhüttl/20.06.2021
public class Lvl4_checkpoint_reached : MonoBehaviour
{
    [SerializeField]
    private int checkPointNumber; // which checkpoint do you wanna save with the gameobject where this script is on
    [SerializeField]
    private GameObject uiMessage; // select ui text, example "reached Checkpoint!"
    [SerializeField]
    private int uiSecondsEnabled = 5; // how long the ui stays on top of the HUD

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerMainBody") // only the parent GO of the player should collide
        {
            Debug.Log("Checkpoint reached with Player: " + other);

            PlayerPrefs.SetInt("lvl4checkpoint", checkPointNumber);

            uiMessage.SetActive(true);
            StartCoroutine(LateCall());
        }
    }
    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(uiSecondsEnabled);

        uiMessage.SetActive(false);
    }
}
