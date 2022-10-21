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
    [SerializeField] private GameObject playerPrefab;
    public GameObject localPlayer;


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
		    _username.Value = PlayerPrefs.GetString("NetClientUsername");
	    }
	    username = _username.Value.ToString();
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public void TryInstantiatePlayerSrpc(ulong requesterID)
    {
	    if (!IsOwner) return;
	    InstantiatePlayerServerRpc(requesterID);
    }
    [ServerRpc(RequireOwnership = false)]
    public void InstantiatePlayerServerRpc(ulong requesterID)
    {
	    //if (!IsOwner) return;
	    var instantiatedPlayer = Instantiate(playerPrefab);
	    instantiatedPlayer.GetComponent<NetworkObject>().Spawn(true);
	    instantiatedPlayer.GetComponent<NetworkObject>().ChangeOwnership(requesterID);
	    localPlayer = instantiatedPlayer;
    }
    

}

