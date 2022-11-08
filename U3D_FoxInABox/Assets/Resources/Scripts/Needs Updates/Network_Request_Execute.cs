//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: 
// Applied to: 
//				Local system manager
// Editor script: 
// Notes: 
//
//=============================================================================

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Network_Request_Execute : NetworkBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=


    //=-----------------=
    // Private Variables
    //=-----------------=
    // Network var of target create object id
    public NetworkVariable<int> targetCreateObjectID
	    = new NetworkVariable<int>(
		    0,
		    NetworkVariableReadPermission.Everyone,
		    NetworkVariableWritePermission.Owner);
    
    public GameObject targetCreateObject;
    public GameObject targetDestroyObject;
    public Transform targetTransform;
    public bool transferOwnership = true;
    public GameObject returnedObject;
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    private Network_Resources networkResources;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
		
    }

    private void Update()
    {
	    if (!networkResources) networkResources = FindObjectOfType<Network_Resources>();
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    [ServerRpc(RequireOwnership = false)]
    public void InstantiateObjectServerRpc(ulong requesterID)
    {
	    // Create reference to instantiated object
	    GameObject instantiatedObject = Instantiate(networkResources.networkPrefabs[targetCreateObjectID.Value], targetTransform.position, targetTransform.rotation);
	    // Spawn the player on the network
	    print(instantiatedObject.name);
	    instantiatedObject.GetComponent<NetworkObject>().Spawn();
	    // Set the instantiated object's owner as the client that sent the request 
	    //if (transferOwnership) instantiatedObject.GetComponent<NetworkObject>().ChangeOwnership(requesterID);
	    // Assign the return object to the instantiated object
	    returnedObject = instantiatedObject;
    }
    
    [ServerRpc(RequireOwnership = false)]
    public void DestroyObjectServerRpc()
    {
	    targetDestroyObject.GetComponent<NetworkObject>().Despawn();
    }
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

