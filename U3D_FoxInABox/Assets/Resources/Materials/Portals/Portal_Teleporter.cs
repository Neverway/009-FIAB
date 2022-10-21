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
using UnityEngine;

public class Portal_Teleporter : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public Transform player;
    public Transform receiver;
    private bool inTrigger;


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
	
    }

    private void Update()
    {
	    if (inTrigger)
	    {
		    Teleport(strictEntry:true);
	    }
    }

    void OnTriggerEnter(Collider other)
    {
	    if (other.tag == "Player")
	    {
		    player = other.gameObject.transform;
		    inTrigger = true;
	    }
    }

    void OnTriggerExit(Collider other)
    {
	    if (other.tag == "Player")
	    {
		    player = null;
		    inTrigger = false;
	    }
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    private void Teleport(bool strictEntry)
    {
	    if (strictEntry)
	    {
		    // Check entry direction
		    Vector3 portalToPlayer = player.position - transform.position;
		    float dotProduct = Vector3.Dot(transform.up, portalToPlayer);
		    
		    // If true, player has traveled across portal
		    if (dotProduct < 0f)
		    {
			    // Flip exit rotation of portal exit
			    float rotationDifference = Quaternion.Angle(transform.rotation, receiver.rotation);
			    rotationDifference += 180;
			    player.Rotate(Vector3.up, rotationDifference);
			    Vector3 positionOffset = Quaternion.Euler(0f, rotationDifference, 0f) * portalToPlayer;
			    // Teleport player
			    player.position = receiver.position + positionOffset;

			    inTrigger = false;
		    }
	    }
	    else
	    {
		    // Check entry direction
		    Vector3 portalToPlayer = player.position - transform.position;
		    
		    // Flip exit rotation of portal exit
		    float rotationDifference = Quaternion.Angle(transform.rotation, receiver.rotation);
		    rotationDifference += 180;
		    player.Rotate(Vector3.up, rotationDifference);
		    Vector3 positionOffset = Quaternion.Euler(0f, rotationDifference, 0f) * portalToPlayer;
		    
		    // Teleport player
		    player.position = receiver.position + positionOffset;

		    inTrigger = false;
	    }
    }
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

