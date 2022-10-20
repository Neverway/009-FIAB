//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// 
// Purpose: 
// Applied to: 
// Notes: 
//
//=============================================================================

using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(Entity_Controller))]
public class Entity_Input_Player : NetworkBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public KeyCode moveForwards = KeyCode.W;
    public KeyCode moveBackwards = KeyCode.S;
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode jump = KeyCode.Space;


    //=-----------------=
    // Private Variables
    //=-----------------=
    private Entity_Controller entityController;
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
        entityController = GetComponent<Entity_Controller>();
    }

    private void Update()
    {
        if (!IsOwner) return;
        // Move vertical
        if (Input.GetKey(moveForwards))
        {
            var movement = entityController.movement;
            entityController.movement = new Vector3(movement.x, movement.y, 1);
        }
        else if (Input.GetKey(moveBackwards))
        {
            var movement = entityController.movement;
            entityController.movement = new Vector3(movement.x, movement.y, -1);
        }
        else
        {
            var movement = entityController.movement;
            entityController.movement = new Vector3(movement.x, movement.y, 0);
        }
	    
        // Move horizontal
        if (Input.GetKey(moveLeft))
        {
            var movement = entityController.movement;
            entityController.movement = new Vector3(-1, movement.y, movement.z);
        }
        else if (Input.GetKey(moveRight))
        {
            var movement = entityController.movement;
            entityController.movement = new Vector3(1, movement.y, movement.z);
        }
        else
        {
            var movement = entityController.movement;
            entityController.movement = new Vector3(0, movement.y, movement.z);
        }
	    
        // Jump
        if (Input.GetKeyDown(jump))
        {
            entityController.Jump();
        }
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

