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
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Network_Manager_Connection : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public UnityTransport transport;
    public TMP_InputField field;


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
	
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public void SetHostIP()
    {
	    if (field.text == "")
	    {
		    transport.ConnectionData.Address = "127.0.0.1";
	    }
	    else
	    {
		    transport.ConnectionData.Address = field.text;
	    }
    }
    public void SetHostPort()
    {
	    if (field.text == "")
	    {
		    ushort port;
		    ushort.TryParse("25565", out port);
		    transport.ConnectionData.Port = port;
	    }
	    else
	    {
		    ushort port;
		    ushort.TryParse(field.text, out port);
		    transport.ConnectionData.Port = port;
	    }
    }
}

