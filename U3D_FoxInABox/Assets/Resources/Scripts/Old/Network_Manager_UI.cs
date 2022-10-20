//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
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
using UnityEngine.UI;

public class Network_Manager_UI : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public Button server;
    public Button host;
    public Button client;


    //=-----------------=
    // Private Variables
    //=-----------------=
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
	    server.onClick.AddListener(() =>
	    {
		    NetworkManager.Singleton.StartServer();
	    });
	    host.onClick.AddListener(() =>
	    {
		    NetworkManager.Singleton.StartHost();
	    });
	    client.onClick.AddListener(() =>
	    {
		    NetworkManager.Singleton.StartClient();
	    });
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
}

