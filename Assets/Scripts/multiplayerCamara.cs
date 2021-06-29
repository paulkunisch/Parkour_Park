using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

// Author: Paul Kunisch 19.06.2021
//fix problems with Cinemachin on multiplayer 
//chaches name of client player game opjects and deactivates the camera 
public class multiplayerCamara : NetworkBehaviour
{
    private GameObject ThirdPersonCamera;
    // Start is called before the first frame update
    void Update()
    {
        ThirdPersonCamera = GameObject.Find("Third Person Camera");
        if (IsClient) 
        {
            ThirdPersonCamera.name = "Third Person Camera-c";
            Debug.Log("Rename tpc" + ThirdPersonCamera.name);
        }

        if (!IsLocalPlayer)
        {
            ThirdPersonCamera.gameObject.SetActive(false); // only allow local camera position
        }
    }

   
}
