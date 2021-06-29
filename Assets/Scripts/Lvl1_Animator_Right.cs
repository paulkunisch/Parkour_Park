using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//David Hasenhuettl /05.04.2021
//Controller for door whit two sides open animation right side
public class Lvl1_Animator_Right : MonoBehaviour
{
    [SerializeField] public Animator myAnimationController2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myAnimationController2.SetBool("DoorRight", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myAnimationController2.SetBool("DoorRight", false);
        }
    }

}
