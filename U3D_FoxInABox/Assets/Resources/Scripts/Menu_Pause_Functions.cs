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
using UnityEngine;

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
    [SerializeField] private GameObject[] toggleActiveOnPlayerSpawn;


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
		    client.InstantiatePlayer();
	    }

	    foreach (var _object in toggleActiveOnPlayerSpawn)
	    {
		    _object.SetActive(!_object.activeInHierarchy);
	    }
    }
    public void LeaveServer()
    {
	    connectionManager.NetworkDisconnect();
	    sceneManager.LoadScene("Title", 0.5f);
    }
}

