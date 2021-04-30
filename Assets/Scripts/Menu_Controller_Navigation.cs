using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Menu_Controller_Navigation : MonoBehaviour
{
    public GameObject mainMenuFirstButton; //, characterFirstButton, creditsFirstButton,
    private void Start()
    {
        // clear selected Object
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selected Object
        EventSystem.current.SetSelectedGameObject(mainMenuFirstButton);
    }
}
