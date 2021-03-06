using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Timo Fröhlich, David Hasenhüttl/08.05.2021
public class Transporter : MonoBehaviour
{
    [SerializeField]
    private GameObject toGo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject character = FindClosestCharacter(); // Player-Collider is not on the parent object, so we have to differentiate

            character.transform.position = toGo.transform.position + new Vector3(0f, 1f, 0f);
        }
    }

    public GameObject FindClosestCharacter()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("PlayerMainBody"); // find all parent GOs of Players
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos) // find closest parent GO from Players
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
}