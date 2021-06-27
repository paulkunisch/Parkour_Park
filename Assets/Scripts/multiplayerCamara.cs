using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

// Author: Paul Kunisch
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
