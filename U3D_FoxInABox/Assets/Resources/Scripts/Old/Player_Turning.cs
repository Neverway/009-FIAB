//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// 
// Purpose: 
// Applied to: 
// Editor script: 
// Notes: 
//
//=============================================================================

using Unity.Netcode;
using UnityEngine;

public class Player_Turning : NetworkBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public float horizontalSensitivity = 100f;
    public float verticalSensitivity = 100f;
    float xRotation;
    public Transform playerBody;

    public bool canMove = true;

    //=-----------------=
    // Private Variables
    //=-----------------=
    private float mouseX;
    private float mouseY;
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=


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
	    if (!IsOwner || !canMove) return;
	    mouseX = Input.GetAxis("Mouse X") * horizontalSensitivity * Time.deltaTime;
	    mouseY = Input.GetAxis("Mouse Y") * verticalSensitivity * Time.deltaTime;

	    xRotation -= mouseY;
	    xRotation = Mathf.Clamp(xRotation, -90f, 90);
	    transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
	    playerBody.Rotate(Vector3.up * mouseX);
    }

    private void FixedUpdate()
    {
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

