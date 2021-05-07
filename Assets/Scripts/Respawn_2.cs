using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_2 : MonoBehaviour

    
{
    
    private Vector3 RespawnPoint = new Vector3(330f, 21f, 330f);
   // private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
       // rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (this.transform.position.y < 2)
        {
            // rb.velocity = Vector3.zero;
            // rb.angularVelocity = Vector3.zero;
            this.transform.position = RespawnPoint;
        }
    }
}
