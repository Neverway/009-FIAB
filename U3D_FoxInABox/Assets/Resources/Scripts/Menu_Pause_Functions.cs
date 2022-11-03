//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// [G2]
// Purpose: 
//			Give functionality to the lobby pause menu options
// Applied to: 
//          The root of the lobby pause screen ui element
// Notes: 
//
//=============================================================================

using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;

public class Menu_Pause_Functions : MonoBehaviour
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
    private Network_Connection_Manager connectionManager;
    private System_SceneManager sceneManager;
    [SerializeField] private UnityEvent OnPlayerCreated;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
	    connectionManager = FindObjectOfType<Network_Connection_Manager>();
	    sceneManager = FindObjectOfType<System_SceneManager>();
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public void SpawnLocalPlayer()
    {
	    // Instantiate the player on the local Network_Client
	    //connectionManager.NetworkLocalClient().InstantiatePlayerServerRpc(NetworkManager.Singleton.LocalClientId);
	    foreach (var client in FindObjectsOfType<Network_Client>())
	    {
		    client.OldInstantiatePlayerServerRpc(NetworkManager.Singleton.LocalClientId);
	    }
	    
	    // Toggle menu items
	    OnPlayerCreated.Invoke();
    }
    
    public void Respawn()
    {
	    // Reset the local player's position to 0,0,0
	    foreach (var player in FindObjectsOfType<Entity_Input_Player>())
	    {
		    if (player.IsOwner) player.ResetPosition();
	    }
    }
    
    public void LeaveServer()
    {
	    connectionManager.NetworkDisconnect();
	    sceneManager.LoadScene("Title", 0.5f);
    }
}

