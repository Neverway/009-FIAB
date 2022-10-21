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
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public void SpawnLocalPlayer()
    {
	    // Instantiate the player on the local Network_Client
	    connectionManager.NetworkLocalClient().InstantiatePlayerServerRpc(NetworkManager.Singleton.LocalClientId);
		
	    // Toggle menu items
	    OnPlayerCreated.Invoke();
    }
    
    public void Respawn()
    {
	    // Reset the local player's position to 0,0,0
	    connectionManager.NetworkLocalClient().localPlayer.GetComponent<Rigidbody>().position = new Vector3(0, 0, 0);
    }
    
    public void LeaveServer()
    {
	    connectionManager.NetworkDisconnect();
	    sceneManager.LoadScene("Title", 0.5f);
    }
}

