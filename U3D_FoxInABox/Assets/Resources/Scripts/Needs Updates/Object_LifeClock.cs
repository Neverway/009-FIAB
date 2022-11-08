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

public class Object_LifeClock : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    [SerializeField] private float lifetime;
    [SerializeField] private bool networkDestroy;


    //=-----------------=
    // Private Variables
    //=-----------------=
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    private Network_Request_Send networkRequest;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private IEnumerator TimeTillDeath()
    {
	    yield return new WaitForSeconds(lifetime);
	    print("expired");
	    if (!networkDestroy) Destroy(gameObject);
	    else
	    {
		    networkRequest.Destroy(gameObject);
	    }
    }
    
    private void Start()
    {
	    networkRequest = FindObjectOfType<Network_Request_Send>();
	    StartCoroutine(TimeTillDeath());
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

