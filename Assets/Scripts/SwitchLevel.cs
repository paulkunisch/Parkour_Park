using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
