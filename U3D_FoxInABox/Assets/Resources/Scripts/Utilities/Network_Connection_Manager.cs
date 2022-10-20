//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// 
// Purpose: 
//			Start connections for server as either Server, Host, or Client, 
//			 and allow the target address and port to be modified
// Applied to: 
//			The root of the Network Manager
// Notes:
//			UnityTransport, the component script that handles connections 
//			 (among other things), uses a data efficient variable type called 
//			 ushort. TryParse is used to turn our string of numbers into a
//           typeOf ushort
//=============================================================================

using System;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;

[RequireComponent(typeof(NetworkManager))]
public class Network_Connection_Manager : MonoBehaviour
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
    [SerializeField] private UnityTransport transport;
    [SerializeField] private NetworkManager networkManager;
    [SerializeField] private TMP_InputField addressField;
    [SerializeField] private TMP_InputField portField;


    //=-----------------=
    // Mono Functions
    //=-----------------=


    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    [Tooltip("Connect to target address and port as dedicatedServer")]
    public void NetworkConnectServer()
    {
	    NetworkManager.Singleton.StartServer();
    }
    [Tooltip("Connect to target address and port as host")]
    public void NetworkConnectHost()
    {
	    NetworkManager.Singleton.StartHost();
    }
    [Tooltip("Connect to target address and port as client")]
    public void NetworkConnectClient()
    {
	    NetworkManager.Singleton.StartClient();
    }
    [Tooltip("Close the server as long as request is sent from server and not host or client")]
    public void NetworkCloseServer()
    {
	    // Keep hosts & clients from closing server
	    if (!networkManager.IsServer)
	    {
		    print("Cannot shutdown server, requester does not have permission to execute this action");
			return;
		}
	    // Disconnect the server
	    networkManager.Shutdown();
    }
    [Tooltip("Disconnect current local user")]
    public void NetworkDisconnectClient()
    {
	    // Keep servers from disconnecting without proper shutdown
	    if (networkManager.IsServer) return;
	    // Disconnect the host or client
	    NetworkManager.Singleton.DisconnectClient(NetworkManager.Singleton.LocalClientId);
    }
    [Tooltip("Set the target network address from TextMeshPro inputField")]
    public void NetworkSetAddress()
    {
	    // Fallback to localhost address if address is not specified
	    if (addressField.text == "") transport.ConnectionData.Address = "127.0.0.1";
	    // Set network address to input field text
	    else transport.ConnectionData.Address = addressField.text;
    }
    [Tooltip("Set the target network port from TextMeshPro inputField")]
    public void NetworkSetPort()
    {
	    
	    // Fallback to 25565 port if port is not specified
	    if (portField.text == "")
	    {
		    ushort.TryParse("25565", out var port);
		    transport.ConnectionData.Port = port;
	    }
	    // Set network port to input field text
	    else
	    {
		    ushort.TryParse(portField.text, out var port);
		    transport.ConnectionData.Port = port;
	    }
    }
}

