//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: Stores the network prefabs in an innumerated list so Network_Request create can spawn objects by ID
// Applied to: 
// Editor script: 
// Notes: 
//
//=============================================================================

using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Network_Resources : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public List<GameObject> networkPrefabs;


    //=-----------------=
    // Private Variables
    //=-----------------=
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    private NetworkManager networkManager;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Awake()
    {
        foreach (var networkPrefab in networkPrefabs)
        {
            // Thanks DavidL#8094!
            NetworkManager.Singleton.AddNetworkPrefab(networkPrefab);
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

