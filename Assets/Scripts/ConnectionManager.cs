using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Spawning;
using System;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using MLAPI.Transports.UNET;
// Author: Paul Kunisch
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
    public string ipAddress = "127.0.0.1";
    UNetTransport transport;
   
    public void HostGame()
    {
        NetworkManager.Singleton.ConnectionApprovalCallback += ApprovalCheck;
        NetworkManager.Singleton.StartHost(sPointHost, Quaternion.identity);
        menuCanvers.SetActive(false);
       
    }

    private void ApprovalCheck(byte[] connectionData, ulong clientID, NetworkManager.ConnectionApprovedDelegate callback)
    {
        bool approve = System.Text.Encoding.ASCII.GetString(connectionData) == "Pa55w.rd";
        Debug.Log("Approving a conection");
        callback(true, null, approve, sPointClient, Quaternion.identity);      
    }

    public void JoinGame()
    {
        transport = NetworkManager.Singleton.GetComponent<UNetTransport>();
        transport.ConnectAddress = ipAddress;
        menuCanvers.SetActive(false);
        NetworkManager.Singleton.StartClient();
        NetworkManager.Singleton.NetworkConfig.ConnectionData = System.Text.Encoding.ASCII.GetBytes("Pa55w.rd");
    }
   
    public void ConectToIPAddress(string newAddress)
    {
        this.ipAddress = newAddress;
    }
}
