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
using UnityEngine;

public class Trigger_Push : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    [SerializeField] private Vector3 force = new Vector3(0,0,5);


    //=-----------------=
    // Private Variables
    //=-----------------=
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    public List<GameObject> ignoredEntities;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    private void OnTriggerStay(Collider other)
    {
	    // If we can't push it, ignore it
	    if (!other.GetComponent<Rigidbody>()) return;
	    
	    // If the object is not ignored
	    if (IsIgnored(other.gameObject)) return;

	    // Add force (forward)
	    other.GetComponent<Rigidbody>().AddForce(transform.forward*force.z, ForceMode.Acceleration);
	    // Add force (up)
	    other.GetComponent<Rigidbody>().AddForce(transform.up*force.y, ForceMode.Acceleration);
	    // Add force (right)
	    other.GetComponent<Rigidbody>().AddForce(transform.right*force.x, ForceMode.Acceleration);
    }
	
    private bool IsIgnored(GameObject target)
    {
	    var result = false;
	    foreach (var entity in ignoredEntities)
	    {
		    if (target == entity) result = true;
	    }
	    return result;
    }

    //=-----------------=
    // External Functions
    //=-----------------=
}

