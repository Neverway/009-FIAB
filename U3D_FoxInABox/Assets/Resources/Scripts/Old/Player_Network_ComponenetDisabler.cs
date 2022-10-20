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

public class Player_Network_ComponenetDisabler : NetworkBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public GameObject[] disableIfNetworkEntity;


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
	    if (IsOwner) return;
	    foreach (var _gameobject in disableIfNetworkEntity)
	    {
		    _gameobject.SetActive(false);
	    }
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

