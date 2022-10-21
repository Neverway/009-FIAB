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
using Unity.Mathematics;
using UnityEngine;

public class Portal_Camera : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public Transform viewCamera;
    public Transform portal;
    public Transform otherPortal;
    public Vector3 positionOffset;
    public quaternion rotationOffset;
    public bool writingView = true;


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

    private void LateUpdate()
    {
	    if (writingView)
	    {
		    //if(FindObjectOfType<Player_Turning>()) viewCamera = FindObjectOfType<Player_Turning>().gameObject.transform;
		    if(Camera.current) viewCamera = Camera.current.gameObject.transform;
	    }
	    
	    if (!viewCamera) return;
	    
	    Vector3 viewOffsetFromPortal = viewCamera.position - otherPortal.position;
	    transform.position = portal.position + viewOffsetFromPortal + positionOffset;

	    float angularDifference = Quaternion.Angle(portal.rotation, otherPortal.rotation);

	    Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifference, Vector3.up);
	    Vector3 newCameraDirection = portalRotationalDifference * viewCamera.forward;
	    transform.rotation = quaternion.LookRotation(newCameraDirection, Vector3.up)*new Quaternion(
		    rotationOffset.value.x,
		    rotationOffset.value.y,
		    rotationOffset.value.z,
		    rotationOffset.value.w);
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

