using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: David Hasenhüttl
public class enabelAnimationOnTrigger : MonoBehaviour // this script is used for the coop element in our multiplayer:
                                                      // enter the collider of the underlying GO and start an animation
{
    [SerializeField]
    private GameObject animatedPlatform; // GO which is to be animated
    void Start()
    {
        animatedPlatform.GetComponent<Animator>().enabled = false; // only move when character stands inside of collider
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject != null) // null-safe
        {
            animatedPlatform.GetComponent<Animator>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameObject != null) // null-safe
        {
            animatedPlatform.GetComponent<Animator>().enabled = false;
        }
    }
}
