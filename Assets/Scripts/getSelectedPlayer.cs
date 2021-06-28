using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Paul Kunisch /18.06.2021
public class getSelectedPlayer : MonoBehaviour
{
    //Variable stores the number of the selected character 
    private int selectedPlayer;

    //Game Objects of the characters
    private GameObject Player1;
    private GameObject Player2;
    private GameObject Player3;
    private GameObject Player4;


    // Start is called before the first frame update
    void Start()
    {
        //Create instances and make sure all characters are disabled
        Player1 = GameObject.Find("Player_1");
        Player2 = GameObject.Find("Player_2");
        Player3 = GameObject.Find("Player_3");
        Player4 = GameObject.Find("Player_4");
        if (Player1.activeSelf) Player1.gameObject.SetActive(false);
        if (Player2.activeSelf) Player2.gameObject.SetActive(false);
        if (Player3.activeSelf) Player3.gameObject.SetActive(false);
        if (Player4.activeSelf) Player4.gameObject.SetActive(false);

        //Only the character that is entered in the PlayerPrefs
        selectedPlayer = PlayerPrefs.GetInt("chosenPlayer");
        //Check charakter number in PlayerPrefs and set this charakter aktiv if nothing is choosen set number to 2
        Debug.Log("Selected character has number: " + selectedPlayer);
        switch (selectedPlayer)
        {
            case 1:
                Player1.gameObject.SetActive(true);
                break;
            case 2:
                Player2.gameObject.SetActive(true);
                break;
            case 3:
                Player3.gameObject.SetActive(true);
                break;
            case 4:
                Player4.gameObject.SetActive(true);
                break;


            default:
                Player2.gameObject.SetActive(true);
                break;
        }        

    }
}
