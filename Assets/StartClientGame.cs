using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartClientGame : MonoBehaviour
{
   public void startGame()
    {
        SceneManager.LoadScene("Level 1mp_King's Castle");
    }
}
