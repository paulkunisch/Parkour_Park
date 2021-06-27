using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl4_Checkpoint_Return : MonoBehaviour
{
    [SerializeField]
    private GameObject respawnPoint1;
    [SerializeField]
    private GameObject respawnPoint2;
    [SerializeField]
    private GameObject respawnPoint3;
    [SerializeField]
    private GameObject respawnPoint4;

    private int checkpoint;

    private void Start()
    {
        PlayerPrefs.SetInt("lvl4checkpoint", 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerMainBody")
        {
            Debug.Log("Player " + other + " fell down");

            checkpoint = PlayerPrefs.GetInt("lvl4checkpoint");

            switch (checkpoint)
            {
                case 1:
                    other.transform.position = respawnPoint1.transform.position;
                    break;
                case 2:
                    other.transform.position = respawnPoint2.transform.position;
                    break;
                case 3:
                    other.transform.position = respawnPoint3.transform.position;
                    break;
                case 4:
                    other.transform.position = respawnPoint4.transform.position;
                    break;

                default:
                    break;

            }
        }

    }

}
