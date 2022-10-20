//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// 
// Purpose: 
// Applied to: 
// Editor script: 
// Notes: 
//
//=============================================================================

using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(Entity_Translate))]
public class Player_Input : NetworkBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public KeyCode moveForwards=KeyCode.W;
    public KeyCode moveBackwards=KeyCode.S;
    public KeyCode moveLeft=KeyCode.A;
    public KeyCode moveRight=KeyCode.D;
    public KeyCode jump=KeyCode.Space;


    //=-----------------=
    // Private Variables
    //=-----------------=


    //=-----------------=
    // Reference Variables
    //=-----------------=
    private Entity_Translate controller;

    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
	    controller = GetComponent<Entity_Translate>();
    }

    private void Update()
    {
	    if (!IsOwner) return;
	    // Move vertical
	    if (Input.GetKey(moveForwards))
	    {
		    var movement = controller.movement;
		    controller.movement = new Vector3(movement.x, movement.y, 1);
	    }
	    else if (Input.GetKey(moveBackwards))
	    {
		    var movement = controller.movement;
		    controller.movement = new Vector3(movement.x, movement.y, -1);
	    }
	    else
	    {
		    var movement = controller.movement;
		    controller.movement = new Vector3(movement.x, movement.y, 0);
	    }
	    
	    // Move horizontal
	    if (Input.GetKey(moveLeft))
	    {
		    var movement = controller.movement;
		    controller.movement = new Vector3(-1, movement.y, movement.z);
	    }
	    else if (Input.GetKey(moveRight))
	    {
		    var movement = controller.movement;
		    controller.movement = new Vector3(1, movement.y, movement.z);
	    }
	    else
	    {
		    var movement = controller.movement;
		    controller.movement = new Vector3(0, movement.y, movement.z);
	    }
	    
	    // Jump
	    if (Input.GetKeyDown(jump))
	    {
		    controller.Jump();
	    }
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

