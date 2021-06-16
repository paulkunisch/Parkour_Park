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
    private Vector3 startP =new Vector3 (325.91f,23f,295.81f);
    public string ipAddress = "127.0.0.1";
    UNetTransport transport;
    public void HostGame()
    {
        menuCanvers.SetActive(false);
        NetworkManager.Singleton.ConnectionApprovalCallback += ApprovalCheck;
        NetworkManager.Singleton.StartHost(startP,Quaternion.identity);
       // SceneManager.LoadScene("Level 1mp_King's Castle");
        

    }

    private void ApprovalCheck(byte[] connectionData, ulong clientID, NetworkManager.ConnectionApprovedDelegate callback)
    {
        bool approve = System.Text.Encoding.ASCII.GetString(connectionData) == "Pa55w.rd";
        Debug.Log("Approving a conection");
        callback(true, null, approve, startP, Quaternion.identity);
        
    }

    public void JoinGame()
    {
        transport = NetworkManager.Singleton.GetComponent<UNetTransport>();
        transport.ConnectAddress = ipAddress;
        menuCanvers.SetActive(false);
        NetworkManager.Singleton.StartClient();
        //Debug.Log("1");
        NetworkManager.Singleton.NetworkConfig.ConnectionData = System.Text.Encoding.ASCII.GetBytes("Pa55w.rd");
        //Debug.Log("2");
       // SceneManager.LoadScene("Level 1mp_King's Castle");
        //Debug.Log("3");
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
