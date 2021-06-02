using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenu_SetPositionGameobject : MonoBehaviour, ISelectHandler
{
    [SerializeField] private float positionx = 0;
    [SerializeField] private float positiony = 0;
    [SerializeField] private float positionz = 0;
    [SerializeField] private GameObject GOtoMove;
    private Vector3 basevalue;
    //Do this when the selectable UI object is selected.
    private void Awake()
    {
        basevalue = GOtoMove.transform.position;
    }
    public void OnSelect(BaseEventData eventData)
    {
        GOtoMove.transform.position = basevalue + new Vector3(positionx, positiony, positionz);
     }
}
