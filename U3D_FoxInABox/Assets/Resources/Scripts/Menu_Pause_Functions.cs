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


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
	    connectionManager = FindObjectOfType<Network_Connection_Manager>();
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
    private void LeaveServer()
    {
	    connectionManager.NetworkDisconnectClient();
    }
}

