using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Spawning;
using System;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using MLAPI.Transports.UNET;
// Author: Paul Kunisch/04.06.2021
// foundation for multiplayer
// builds connection between host and clients
// sets password and spawnpoints 
public class ConnectionManager : MonoBehaviour
{
    //Stores multiplayer staring menu 
    public GameObject menuCanvers;
   //Stores staring point of the host
    private Vector3 sPointHost = new Vector3 (-95.67f,200f,-2306.7f);
    //Stores staring point of the client
    private Vector3 sPointClient = new Vector3(-95f,200f,-2303.25f);
    public string ipAddress; //= "127.0.0.1"; //just for testing 
    UNetTransport transport;
   
    public void HostGame()
    {
        NetworkManager.Singleton.ConnectionApprovalCallback += ApprovalCheck;
        NetworkManager.Singleton.StartHost(sPointHost, Quaternion.identity); //activats Host Connection with given vector
        menuCanvers.SetActive(false); //deactivates UI for host
       
    }

    private void ApprovalCheck(byte[] connectionData, ulong clientID, NetworkManager.ConnectionApprovedDelegate callback)
    { //checks the password of an incoming client and build the conection 
        bool approve = System.Text.Encoding.ASCII.GetString(connectionData) == "Pa55w.rd";
        Debug.Log("Approving a conection");
        callback(true, null, approve, sPointClient, Quaternion.identity);      
    }

    public void JoinGame()
    {
        transport = NetworkManager.Singleton.GetComponent<UNetTransport>();
        transport.ConnectAddress = ipAddress; 
        menuCanvers.SetActive(false); //deactivates UI for client
        NetworkManager.Singleton.StartClient();
        NetworkManager.Singleton.NetworkConfig.ConnectionData = System.Text.Encoding.ASCII.GetBytes("Pa55w.rd");
    }
   
    public void ConectToIPAddress(string newAddress)
    {
        this.ipAddress = newAddress;
    }
}
