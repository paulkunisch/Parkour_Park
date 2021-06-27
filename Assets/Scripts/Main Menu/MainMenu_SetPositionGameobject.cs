using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Author: David Hasenhüttl
// this script allows to use buttons with a controller inside of scrollviews of the UI
// Note: if you have any other option, don't replicate this.
//       way too much work, way too many sources of error
public class MainMenu_SetPositionGameobject : MonoBehaviour, ISelectHandler
{
    [SerializeField] private float positionx = 0; // x,y,z values to add to start-coordinates
    [SerializeField] private float positiony = 0;
    [SerializeField] private float positionz = 0;
    [SerializeField] private GameObject GOtoMove; // scrollview bar
    private Vector3 basevalue; // save start-coordinates

    //Do this when the selectable UI object is selected.
    private void Awake()
    {
        basevalue = GOtoMove.transform.position;
    }
    public void OnSelect(BaseEventData eventData)
    {
        GOtoMove.transform.position = basevalue + new Vector3(positionx, positiony, positionz); // moves the scrollview to specified location once the button has been selected
     }
}
