using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Paul Kunisch/28.06.2021
//Rotates PowerUps

public class RotatePowerUp : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);//rotates its parent gameobject 
    }
}
