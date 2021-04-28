using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
