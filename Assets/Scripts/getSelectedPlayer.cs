using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getSelectedPlayer : MonoBehaviour
{
    private int selectedPlayer;
    private GameObject Player1;
    private GameObject Player2;
    private GameObject Player3;
    private GameObject Player4;


    // Start is called before the first frame update
    void Start()
    {
        Player1 = GameObject.Find("Player_1");
        Player2 = GameObject.Find("Player_2");
        Player3 = GameObject.Find("Player_3");
        Player4 = GameObject.Find("Player_4");
        Player1.gameObject.SetActive(false);
        Player2.gameObject.SetActive(false);
        Player3.gameObject.SetActive(false);
        Player4.gameObject.SetActive(false);

        selectedPlayer = PlayerPrefs.GetInt("chosenPlayer");
        Debug.Log("Player is " + selectedPlayer);
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
        }        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
