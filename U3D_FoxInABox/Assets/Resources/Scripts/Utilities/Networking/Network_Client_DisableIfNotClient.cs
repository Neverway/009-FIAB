//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// 
// Purpose:  
//			Disable objects in list if the current object is not the local client
// Applied to: 
//			The root of the net player prefab
// Notes:  
//			This is used for doing things like disabling cameras on net players
//			 so the only active view will be from the local player
//
//=============================================================================

using Unity.Netcode;
using UnityEngine;

public class Network_Client_DisableIfNotClient : NetworkBehaviour
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
    [SerializeField] private GameObject[] clientObjects;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
	    // Exit if we're the local client
	    if (IsOwner) return;
	    
	    // Disable all objects
	    foreach (var objects in clientObjects)
	    {
		    objects.SetActive(false);
	    }
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

