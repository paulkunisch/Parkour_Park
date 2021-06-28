using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MLAPI;
//Author:Paul Kunisch 
//Script to close netwokeconections if multiplayer is closed 

public class DisconnectOnExitMultiplayer : NetworkBehaviour
{
    public string sceneToGo = "MainMenu";

    public void DisconnectSession(string sceneToGo)
    {
        /*if (IsHost)
        {
            Time.timeScale = 1f;
            NetworkManager.Singleton.StopClient();
            NetworkManager.Singleton.StopHost();
            SceneManager.LoadScene(sceneToGo);
            Debug.Log("Sessions Stoped");
        }*/
       
        if (IsClient)
        {
            Time.timeScale = 1f;
            NetworkManager.Singleton.StopClient();           
            SceneManager.LoadScene(sceneToGo);
            Debug.Log("Client Session Stoped");
        }
        else
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(sceneToGo);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
