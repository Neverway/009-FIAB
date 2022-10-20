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
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

public class Network_Client : NetworkBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public string username;


    //=-----------------=
    // Private Variables
    //=-----------------=
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private NetworkVariable<FixedString32Bytes> _username 
	    = new NetworkVariable<FixedString32Bytes>(
		    "MissingData",
		    NetworkVariableReadPermission.Everyone,
		    NetworkVariableWritePermission.Owner);

    private void Start()
    {
    }

    private void Update()
    {
	    Debug.Log(OwnerClientId + "; UName: " + _username.Value);
	    if (!IsOwner)
	    {
		    
	    }
	    else
	    {
		    _username.Value = PlayerPrefs.GetString("NetworkClientUsername", "wow");
	    }
	    username = _username.Value.ToString();
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    

}

