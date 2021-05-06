using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transporter : MonoBehaviour
{
    public CharacterController CharacterController;
    [SerializeField] private GameObject toGo;
    private void Start()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (null != toGo)
        {
            CharacterController.enabled = false;
           // other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
           // other.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            other.transform.position = toGo.transform.position + new Vector3(0, 1, 0);
            CharacterController.enabled = true;
        }
       // Debug.Log("#### DMTTRigggerAnimation Teleporter: " + this.gameObject.name + " <>");
        //Debug.Log(toGo.transform.position);
    }
}
