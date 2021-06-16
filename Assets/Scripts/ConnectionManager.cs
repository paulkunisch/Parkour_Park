using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Spawning;
using System;
using UnityEngine.SceneManagement;

public class ConnectionManager : MonoBehaviour
{
    //TODO:SpawnPoints je Level
    private Vector3 startP =new Vector3 (8.435f,2.21f,-91.84f); 
    public void HostGame()
    {
      
        NetworkManager.Singleton.ConnectionApprovalCallback += ApprovalCheck;
        NetworkManager.Singleton.StartHost(startP,Quaternion.identity);
        SceneManager.LoadScene("Level 1mp_King's Castle");

    }

    private void ApprovalCheck(byte[] connectionData, ulong clientID, NetworkManager.ConnectionApprovedDelegate callback)
    {
       // bool approve = System.Text.Encoding.ASCII.GetString(connectionData) == "Pa55w.rd";
        Debug.Log("Approving a conection");
        callback(true, null, true, startP, Quaternion.identity);
        
    }

    public void JoinGame()
    {
       
        NetworkManager.Singleton.StartClient();
        Debug.Log("1");
        //NetworkManager.Singleton.NetworkConfig.ConnectionData = System.Text.Encoding.ASCII.GetBytes("Pa55w.rd");
        Debug.Log("2");
        SceneManager.LoadScene("Level 1mp_King's Castle");
        Debug.Log("3");
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
