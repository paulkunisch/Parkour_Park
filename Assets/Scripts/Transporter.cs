using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transporter : MonoBehaviour
{
    private GameObject toGo;
    private void Start()
    {
        toGo = GameObject.Find("Teleporter_1");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (null != toGo)
        {
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            other.transform.position = toGo.transform.position + new Vector3(0, 1, 0);
        }
        Debug.Log("#### DMTTRigggerAnimation Teleporter: " + this.gameObject.name + " <>");
    }
}
