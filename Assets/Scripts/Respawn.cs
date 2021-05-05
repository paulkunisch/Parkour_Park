using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform respawn_Point;

        void OnTriggerEnter(Collider other)
    {
        Player.transform.position = respawn_Point.transform.position;
    }
}
