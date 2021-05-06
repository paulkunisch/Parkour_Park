using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    // [SerializeField] private Transform Player;
    public GameObject Player;
    public Vector3 RespawnPoint;
    //[SerializeField] private Transform respawn_Point;

    private void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Player.transform.position = RespawnPoint;
    }
}
