using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollideBackToSpawn : MonoBehaviour
{
    //Respawn
    private int respawnPoint;

    [SerializeField]
    public GameObject respawnPoint1;
    [SerializeField]
    public GameObject respawnPoint2;
    [SerializeField]

    public void Start()
    {
        // Respawn
        PlayerPrefs.SetInt("respawnPoint", 1);
    }

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

        respawnPoint = PlayerPrefs.GetInt("respawnPoint");

        switch (respawnPoint)
        {
            case 1:
                character.transform.position = respawnPoint1.transform.position;
                break;
            case 2:
                character.transform.position = respawnPoint2.transform.position;
                break;
        }
    }
}