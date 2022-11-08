//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: 
// Applied to: 
//              Persistant system manager
// Editor script: 
// Notes: 
//
//=============================================================================

using UnityEngine;
using Unity.Netcode;

public class Network_Request_Send : MonoBehaviour
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
    public Network_Request_Execute networkRequestExecute;
    public Network_Resources networkResources;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Update()
    {
        if (!networkRequestExecute) networkRequestExecute = FindObjectOfType<Network_Request_Execute>();
        if (!networkResources) networkResources = FindObjectOfType<Network_Resources>();
    }


    //=-----------------=
    // Internal Functions
    //=-----------------=
    /*
    private bool GetIsHost()
    {
        // Look through the clients on the server
        foreach (var client in FindObjectsOfType<Network_Client>())
        {
            // If we're that client
            if (client.OwnerClientId == NetworkManager.Singleton.LocalClientId)
            {
                // If we're host
                if (NetworkManager.Singleton.IsHost)
                {
                    return true;
                }

                return false;
            }
        }

        print("Didn't exit properly. Please investigate");
        return false;
    }*/

    private int GetObjectNetID(GameObject _targetObject)
    {
        for (int i = 0; i < networkResources.networkPrefabs.Count; i++)
        {
            if (networkResources.networkPrefabs[i].gameObject.name == _targetObject.name)
            {
                print(networkResources.networkPrefabs[i].gameObject.name + " = " + _targetObject.name+" ("+i+")");
                return i;
            }
        }

        print("failed to find net prefab for object");
        return 0;
    }
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public void Create(ulong requesterID, GameObject _targetObject, Transform _transform, bool _transferOwnership)
    {
        // Send data to executor
        // Assign this on all net instances
        networkRequestExecute.targetCreateObjectID.Value = GetObjectNetID(_targetObject);
        //networkRequestExecute.targetCreateObject = _targetObject;
        networkRequestExecute.targetTransform = _transform;
        networkRequestExecute.transferOwnership = _transferOwnership;

        // Create the object
        networkRequestExecute.InstantiateObjectServerRpc(requesterID);
    }
    public void Destroy(GameObject _targetObject)
    {
        networkRequestExecute.targetDestroyObject = _targetObject;
        
        networkRequestExecute.DestroyObjectServerRpc();
    }
    /*
    public GameObject Create(ulong requesterID, GameObject _targetObject, Transform _transform, bool _transferOwnership)
    {
        networkRequestExecute.targetCreateObject = _targetObject;
        networkRequestExecute.targetTransform = _transform;
        networkRequestExecute.transferOwnership = _transferOwnership;

        print("02");
        if (GetIsHost()) networkRequestExecute.InstantiateObject(requesterID);
        if (!GetIsHost())
        {
            print("01");
            networkRequestExecute.InstantiateObjectServerRpc(requesterID);
        }
        
        // Return the created object
        return networkRequestExecute.returnedObject;
    }
    public void Destroy(GameObject _targetObject)
    {
        networkRequestExecute.targetDestroyObject = _targetObject;
        
        if (GetIsHost()) networkRequestExecute.DestroyObject();
        if (!GetIsHost())  networkRequestExecute.DestroyObjectServerRpc();
    }*/
}

