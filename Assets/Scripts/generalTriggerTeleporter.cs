using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Author: David Hasenhüttl
* this script handles teleporting our player Gameobjects after a player has entered the collider
* and pressed the corresponding button
* an easier way would be to use the "other" collider to select the character colliding,
* however this is not working for us since we have our controller script located on the
* Parent Gameobject, while we use multiple colliders that are located on a child GO named Mesh.
* this gameobject needs an collider that is placed in front of the object (eg. a door)
*/
public class generalTriggerTeleporter : MonoBehaviour
{

    [SerializeField]
    private GameObject toGo; // just drag a Gameobject here, your character will teleport to its location when you press the corresponding button (slightly above it)
    [SerializeField]
    private GameObject UI_text; // set an UI text elements which says something like "press Space or gamepad B to teleport"

    private bool isin = false;


    public void Update()
    {
        if (isin == true)
        {
            if (toGo != null && (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("nextLevel")))
            {
                GameObject character = FindClosestCharacter(); // Player-Collider is not on the parent object, so we have to differentiate

                character.transform.position = toGo.transform.position + new Vector3(0f, 1f, 0f);

            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        UI_text.SetActive(true);
        isin = true;
    }

    public void OnTriggerExit(Collider other)
    {
        UI_text.SetActive(false);
        isin = false;
    }


    public GameObject FindClosestCharacter()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("PlayerMainBody"); // find all parent GOs of Players
        GameObject closest = null; // this variable holds the currently closest player
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos) // find closest parent GO from Players
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
