using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class MultiplayerOnCollideBackToSpawn : NetworkBehaviour
{
    private Vector3 RespawnPoint = new Vector3(330f, 21f, 330f);

    public GameObject FindClosestCharacter()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("PlayerMainBody");
        Debug.Log(gos.Length);
        if (gos.Length == 1) return gos[0];
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
           
            if (go.gameObject.GetComponent<NetworkBehaviour>().IsLocalPlayer)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance;
                }
            }
        }
        return closest;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject character = FindClosestCharacter();

        Debug.Log(character);
        character.transform.position = RespawnPoint;
    }
}