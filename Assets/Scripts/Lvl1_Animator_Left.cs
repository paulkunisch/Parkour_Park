using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//David Hasenhuettl /05.04.2021
//Controller for door whit two sides open animation left side

public class Lvl1_Animator_Left : MonoBehaviour 
{
    [SerializeField] private Animator myAnimationController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myAnimationController.SetBool("DoorLeft", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myAnimationController.SetBool("DoorLeft", false);
        }
    }

}
