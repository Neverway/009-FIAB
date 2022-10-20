//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// 
// Purpose: 
// Applied to: 
// Editor script: 
// Notes: 
//
//=============================================================================

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Entity_Translate : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public Vector3 movement;
    public float speed = 1000;
    
    public float currentJumpForce;
    public float jumpForce = 100;
    public LayerMask groundLayers;

    public float groundDrag;
    public float airDrag;
    public float airMovementMultiplier;


    //=-----------------=
    // Private Variables
    //=-----------------=
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    private Rigidbody entityRigidbody;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
	    entityRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
	    switch(IsGrounded())
	    {
		    case true:
		    {
			    entityRigidbody.AddForce(transform.forward * movement.z * speed * Time.deltaTime, ForceMode.Acceleration);
			    entityRigidbody.AddForce(transform.right * movement.x * speed * Time.deltaTime, ForceMode.Acceleration);
			    entityRigidbody.drag = groundDrag;
			    break;
		    }
		    case false:
		    {
			    entityRigidbody.AddForce(transform.forward * movement.z * airMovementMultiplier * speed * Time.deltaTime, ForceMode.Acceleration);
			    entityRigidbody.AddForce(transform.right * movement.x * airMovementMultiplier * speed * Time.deltaTime, ForceMode.Acceleration);
			    entityRigidbody.drag = airDrag;
			    break;
		    }
	    }
	    
	    entityRigidbody.AddForce(transform.up * currentJumpForce * Time.deltaTime, ForceMode.Force);
	    
	    if (!IsGrounded()) currentJumpForce = 0;
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    private bool IsGrounded()
    {
	    return (Physics.SphereCast(transform.position,0.2f,Vector3.down,out var hit,1.1f,groundLayers));
    }


    //=-----------------=
    // External Functions
    //=-----------------=
    
    public void Jump()
    {
	    if (IsGrounded()) currentJumpForce = jumpForce;
    }
}

