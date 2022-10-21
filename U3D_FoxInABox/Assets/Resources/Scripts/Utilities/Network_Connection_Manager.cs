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

public class Network_Connection_Manager : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public string targetAddress;
    public string targetPort;


    //=-----------------=
    // Private Variables
    //=-----------------=
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    private UnityTransport transport;
    private NetworkManager networkManager;
    [SerializeField] private TMP_InputField addressField;
    [SerializeField] private TMP_InputField portField;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Update()
    {
	    transport = FindObjectOfType<UnityTransport>();
	    networkManager = FindObjectOfType<NetworkManager>();
	    
	    // Create starting NetTarget prefs
	    if (!PlayerPrefs.HasKey("NetTargetAddress")) PlayerPrefs.SetString("NetTargetAddress", "127.0.0.1");
	    if (!PlayerPrefs.HasKey("NetTargetPort")) PlayerPrefs.SetString("NetTargetPort", "25565");

	    // Set local vars to NetTarget prefs (makes code look neater)
	    targetAddress = PlayerPrefs.GetString("NetTargetAddress");
	    targetPort = PlayerPrefs.GetString("NetTargetPort");
	    
	    // Assign NetTarget to transport
	    transport.ConnectionData.Address = targetAddress;
	    ushort.TryParse(portField.text, out var port);
	    transport.ConnectionData.Port = port;
    }
    

    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    [Tooltip("Connect to target address and port as dedicatedServer")]
    public void NetworkConnectServer()
    {
	    networkManager.StartServer();
    }
    [Tooltip("Connect to target address and port as host")]
    public void NetworkConnectHost()
    {
		networkManager.StartHost();
    }
    [Tooltip("Connect to target address and port as client")]
    public void NetworkConnectClient()
    {
	    networkManager.StartClient();
    }
    [Tooltip("Shutdown the server")]
    public void NetworkDisconnect()
    {
	    // Disconnect the server
	    networkManager.Shutdown();
    }
    [Tooltip("Set the target network address from TextMeshPro inputField")]
    public void NetworkSetAddress()
    {
	    // Fallback to localhost address if address is not specified
	    if (addressField.text == "") PlayerPrefs.SetString("NetTargetAddress", "127.0.0.1");
	    // Set network address to input field text
	    else PlayerPrefs.SetString("NetTargetAddress", addressField.text);
    }
    [Tooltip("Set the target network port from TextMeshPro inputField")]
    public void NetworkSetPort()
    {
	    // Fallback to localhost port if port is not specified
	    if (portField.text == "") PlayerPrefs.SetString("NetTargetPort", "25565");
	    // Set network address to input field text
	    else PlayerPrefs.SetString("NetTargetPort", portField.text);
    }
}

