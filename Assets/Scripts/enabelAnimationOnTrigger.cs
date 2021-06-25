using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enabelAnimationOnTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject animatedPlatform;
    void Start()
    {
        animatedPlatform.GetComponent<Animator>().enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject != null)
        {
            animatedPlatform.GetComponent<Animator>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameObject != null)
        {
            animatedPlatform.GetComponent<Animator>().enabled = false;
        }
    }
}
