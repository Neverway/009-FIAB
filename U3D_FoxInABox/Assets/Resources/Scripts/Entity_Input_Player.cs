//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// 
// Purpose: 
//          Allow the local player to posses an entity
// Applied to: 
//          The root of an entity controller
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
    [Header("Controls")]
    [SerializeField] private KeyCode moveForwards = KeyCode.W;
    [SerializeField] private KeyCode moveBackwards = KeyCode.S;
    [SerializeField] private KeyCode moveLeft = KeyCode.A;
    [SerializeField] private KeyCode moveRight = KeyCode.D;
    [SerializeField] private KeyCode jump = KeyCode.Space;


    //=-----------------=
    // Private Variables
    //=-----------------=
    // Used by the system pause script to freeze the player when a menu is open
    public bool canMove = true;
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    private Entity_Controller entityController;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
        entityController = GetComponent<Entity_Controller>();
    }

    private void Update()
    {
        // Exit if this instance is not the local player, or the local player is frozen
        //if (!IsOwner || !canMove) return;
        
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
    public void ResetPosition()
    {
        entityController.ResetPosition();
    }
}

