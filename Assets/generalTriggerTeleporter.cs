using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class generalTriggerTeleporter : MonoBehaviour
{

    [SerializeField]
    private GameObject toGo;
    [SerializeField]
    private GameObject UI_text;

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
        GameObject closest = null;
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
