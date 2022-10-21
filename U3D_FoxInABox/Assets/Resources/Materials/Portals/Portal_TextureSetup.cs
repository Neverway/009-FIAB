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

public class Portal_TextureSetup : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public Camera cameraA;
    public Camera cameraB;
    public Material cameraMatA;
    public Material cameraMatB;


    //=-----------------=
    // Private Variables
    //=-----------------=
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Update()
    {
	    if (cameraA.targetTexture != null) cameraA.targetTexture.Release();
	    cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
	    cameraMatA.mainTexture = cameraA.targetTexture;
	    
	    if (cameraB.targetTexture != null) cameraB.targetTexture.Release();
	    cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
	    cameraMatB.mainTexture = cameraB.targetTexture;
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

