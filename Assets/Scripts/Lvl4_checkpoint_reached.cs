using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl4_checkpoint_reached : MonoBehaviour
{
    [SerializeField]
    private int checkPointNumber;
    [SerializeField]
    private GameObject uiMessage;
    [SerializeField]
    private int uiSecondsEnabled = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerMainBody")
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
