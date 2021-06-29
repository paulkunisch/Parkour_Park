using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MLAPI;
//Author:Paul Kunisch /28.06.2021
//Script to close netwokeconections if multiplayer is closed by Client
//to enable reconection to the same session

public class DisconnectOnExitMultiplayer : NetworkBehaviour
{
    public string sceneToGo = "MainMenu";

    public void DisconnectSession(string sceneToGo)
    {
       
        if (IsClient)
        {
            Time.timeScale = 1f;//if Pause time frise from pausmenue back to normal
            NetworkManager.Singleton.StopClient(); //stops client connection         
            SceneManager.LoadScene(sceneToGo); //loads given scene
            Debug.Log("Client Session Stoped");
        }
        else
        {
            Time.timeScale = 1f;// rectivats time client if Host leafs
            SceneManager.LoadScene(sceneToGo); //enables the client to go back to main menu
        }
    }

   
}
