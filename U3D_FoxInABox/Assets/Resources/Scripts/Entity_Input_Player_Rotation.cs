//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// [G2]
// Purpose: 
//			Rotate the local player controlled entity using FPS style movement
// Applied to: 
//			The view holder on a player controlled entity
// Notes: 
//
//=============================================================================

using Unity.Netcode;
using UnityEngine;

public class Entity_Input_Player_Rotation : NetworkBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    [Header("Controls")]
    public float horizontalSensitivity = 100f;
    public float verticalSensitivity = 100f;

    //=-----------------=
    // Private Variables
    //=-----------------=
    private float mouseX;
    private float mouseY;
    private float xRotation;

    // Used by the system pause script to freeze the player when a menu is open
    public bool canMove = true;
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    [SerializeField] private Transform playerBody;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
	    if (!IsOwner) return;
	    Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
	    // Exit if this instance is not the local player, or the local player is frozen
	    if (!IsOwner || !canMove) return;
	    
	    // Get mouse movement
	    mouseX = Input.GetAxis("Mouse X") * horizontalSensitivity * Time.deltaTime;
	    mouseY = Input.GetAxis("Mouse Y") * verticalSensitivity * Time.deltaTime;

	    // Clamp vertical axis to keep player neck from looking to far up or down
	    xRotation -= mouseY;
	    xRotation = Mathf.Clamp(xRotation, -90f, 90);
	    
	    // Apply rotations
	    transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
	    playerBody.Rotate(Vector3.up * mouseX);
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

