using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollideBackToSpawn : MonoBehaviour
{
    private Vector3 RespawnPoint = new Vector3(330f, 21f, 330f);

    public GameObject FindClosestCharacter()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("PlayerMainBody");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject character = FindClosestCharacter();

        character.transform.position = RespawnPoint;
    }
}