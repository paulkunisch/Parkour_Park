using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class multiplayerCamara : NetworkBehaviour
{
    private GameObject ThirdPersonCamera;
    // Start is called before the first frame update
    void Start()
    {
        ThirdPersonCamera = GameObject.Find("Third Person Camera");
        if (IsClient)
        {
            ThirdPersonCamera.name = "Third Person Camera-c";
            Debug.Log("Rename tpc" + ThirdPersonCamera.name);
        }

        if (!IsLocalPlayer)
        {
            ThirdPersonCamera.gameObject.SetActive(false);
        }
    }

   
}
