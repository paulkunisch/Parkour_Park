using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Paul Kunisch/18.06.2021
public class savePlayer : MonoBehaviour
{  
    // select the current Player in Singleplayer from PlayerPrefs
    public void setPlayer1()
    {
        Debug.Log("aktuller charakter ist Spieler 1");
        PlayerPrefs.SetInt("chosenPlayer", 1);
    }
    public void setPlayer2()
    {
        Debug.Log("aktuller charakter ist Spieler 2");
        PlayerPrefs.SetInt("chosenPlayer", 2);
    }
    public void setPlayer3()
    {
        Debug.Log("aktuller charakter ist Spieler 3");
        PlayerPrefs.SetInt("chosenPlayer", 3);
    }
   public void setPlayer4()
    {
        Debug.Log("aktuller charakter ist Spieler 4");
        PlayerPrefs.SetInt("chosenPlayer", 4);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
