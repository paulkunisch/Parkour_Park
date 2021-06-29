using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Author: David Hasenhüttl/09.05.2021
public class SwitchLevel : MonoBehaviour
{
    [SerializeField]
private string whichScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(whichScene);
        }
    }
}
