//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: 
// Applied to: 
// Editor script: 
// Notes: 
//
//=============================================================================

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Entity_Player_Abilities : NetworkBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public KeyCode shoveKey;
    public float shoveCooldownTime = 1f;


    //=-----------------=
    // Private Variables
    //=-----------------=
    [SerializeField] private bool shoveCooldown;
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    [SerializeField] private Entity_Input_Player player;
    [SerializeField] private Network_Request_Send networkRequest;
    [SerializeField] private GameObject shoveTrigger;
    [SerializeField] private GameObject defaultCube;
    [SerializeField] private Transform shoveTransform;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private IEnumerator ShoveCooldown()
    {
	    shoveCooldown = true;
	    yield return new WaitForSeconds(shoveCooldownTime);
	    shoveCooldown = false;
    }

    private void Start()
    {
	    if (!player) player = GetComponent<Entity_Input_Player>();
	    if (!networkRequest) networkRequest = FindObjectOfType<Network_Request_Send>();
    }

    private void Update()
    {
	    // Exit if this instance is not the local player, or the local player is frozen
	    if (!IsOwner || !player.canMove) return;
	    
	    // Shove
	    if (Input.GetKeyDown(shoveKey) && !shoveCooldown) Shove();
	    
	    // Test
	    if (Input.GetKeyDown(KeyCode.F1)) Test();
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    private void Shove()
    {
	    // Spawn the effect trigger
	    networkRequest.Create(NetworkManager.Singleton.LocalClientId, shoveTrigger, shoveTransform, true);
	    
	    /*
	    // Look through the clients on the server
	    foreach (var client in FindObjectsOfType<Network_Client>())
	    {
		    // If we're that client
		    if (client.OwnerClientId == NetworkManager.Singleton.LocalClientId && networkRequest)
		    {
			    var _shoveTrigger = networkRequest.Create(NetworkManager.Singleton.LocalClientId, shoveTrigger, shoveTransform, true);
			    if (!_shoveTrigger) return; 
			    // Add the local player to the ignored entities
			    //_shoveTrigger.GetComponent<Trigger_Push>().ignoredEntities.Add(gameObject);
		    }
	    }*/
	    
	    // Start the shove cooldown
	    StartCoroutine(ShoveCooldown());
    }
    private void Test()
    {
	    // Spawn the effect trigger
	    networkRequest.Create(NetworkManager.Singleton.LocalClientId, defaultCube, shoveTransform, true);
    }
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

