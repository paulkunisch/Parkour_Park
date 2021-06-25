using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class PlayerMoveWithPlattform : NetworkBehaviour
{
    private GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        go = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == go && IsLocalPlayer)
        {
            go.transform.parent = transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == go)
        {
            go.transform.parent = null;
        }

    }
}
