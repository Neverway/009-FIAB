//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: 
// Applied to: 
// Editor script: 
// Notes: 
//
//=============================================================================

using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;

public class Menu_Pause_Functions : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=


    //=-----------------=
    // Private Variables
    //=-----------------=
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    private Network_Connection_Manager connectionManager;
    private System_SceneManager sceneManager;
    [SerializeField] private UnityEvent OnPlayerCreated;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
	    connectionManager = FindObjectOfType<Network_Connection_Manager>();
	    sceneManager = FindObjectOfType<System_SceneManager>();
    }

    private void Update()
    {
	
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public void SpawnLocalPlayer()
    {
	    foreach (var client in FindObjectsOfType<Network_Client>())
	    {
		    client.InstantiatePlayerServerRpc(NetworkManager.Singleton.LocalClientId);
	    }

	    OnPlayerCreated.Invoke();
    }
    public void Respawn()
    {
	    foreach (var client in FindObjectsOfType<Network_Client>())
	    {
		    if(!client.IsOwner) { print("Reject");return; }
		    client.localPlayer.GetComponent<Rigidbody>().position = new Vector3(0, 0, 0);
		    print(client.localPlayer.GetComponent<Rigidbody>());
	    }
    }
    public void LeaveServer()
    {
	    connectionManager.NetworkDisconnect();
	    sceneManager.LoadScene("Title", 0.5f);
    }
}

