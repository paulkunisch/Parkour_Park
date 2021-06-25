using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Spawning;
using System;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using MLAPI.Transports.UNET;

public class ConnectionManager : MonoBehaviour
{
    public GameObject menuCanvers;
   // public GameObject mainCamera;
    private Vector3 startP = new Vector3 (325f,24f,302f);
    private Vector3 startPC = new Vector3(327f,23f,310f);
    public string ipAddress = "127.0.0.1";
    UNetTransport transport;
   
    public void HostGame()
    {
        NetworkManager.Singleton.ConnectionApprovalCallback += ApprovalCheck;
        NetworkManager.Singleton.StartHost(startP,Quaternion.identity);
        menuCanvers.SetActive(false);
       
    }

    private void ApprovalCheck(byte[] connectionData, ulong clientID, NetworkManager.ConnectionApprovedDelegate callback)
    {
        bool approve = System.Text.Encoding.ASCII.GetString(connectionData) == "Pa55w.rd";
        Debug.Log("Approving a conection");
        callback(true, null, approve, startPC, Quaternion.identity);      
    }

    public void JoinGame()
    {
        transport = NetworkManager.Singleton.GetComponent<UNetTransport>();
        transport.ConnectAddress = ipAddress;
        menuCanvers.SetActive(false);
        NetworkManager.Singleton.StartClient();
        NetworkManager.Singleton.NetworkConfig.ConnectionData = System.Text.Encoding.ASCII.GetBytes("Pa55w.rd");
    }
    Vector3 GetRandomSpawn()
    {
        float x = Random.Range(-5f, 5f);
        float y = Random.Range(-5f, 5f);
        float z = Random.Range(-5f, 5f);
        return new Vector3(x, y, z);
    }
    public void ConectToIPAddress(string newAddress)
    {
        this.ipAddress = newAddress;
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
