//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// [G2]
// Purpose: 
//			Give a rigidbody game object the ability to move and jump
// Applied to: 
//			A the root of a rigidbody entity
// Notes: 
//
//=============================================================================

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Entity_Controller : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    [Header("Movement")]
    public Vector3 movement;
    [Tooltip("How fast the entity will move")]
    public float speed = 1300;
    
    [Header("Jumping")]
    [Tooltip("How high the entity will jump")]
    public float jumpForce = 5000;
    [Tooltip("Which layers are considered to be ground (Used for allowing jumping)")]
    public LayerMask groundLayers;
    [Tooltip("The position to start the ground check spherecast")]
    public Transform groundCheck;
    [Tooltip("The radius of the ground check spherecast")]
    public float groundCheckRadius = 0.1f;
    [Tooltip("Max distance downward to check for ground from edge of spherecast")]
    public float maxDistance = 0.1f;

    [Header("Drag")]
    [Tooltip("The drag of the rigidbody when grounded")]
    public float groundDrag = 4;
    [Tooltip("The drag of the rigidbody when airborne")]
    public float airDrag = 0.2f;
    [Tooltip("Used to set entity air control (Lower the number, the less control)")]
    public float airMovementMultiplier = 0.1f;


    //=-----------------=
    // Private Variables
    //=-----------------=
    private float currentJumpForce;
    
    
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
	    // Switch between grounded and airborne movement
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
	    
	    // Jump force
	    entityRigidbody.AddForce(transform.up * currentJumpForce * Time.deltaTime, ForceMode.Force);
	    
	    // Keep entity from jumping in air
	    if (!IsGrounded()) currentJumpForce = 0;
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    private bool IsGrounded()
    {
	    return (Physics.SphereCast(groundCheck.position,groundCheckRadius,Vector3.down,out var hit,maxDistance,groundLayers));
    }


    //=-----------------=
    // External Functions
    //=-----------------=
    public void Jump()
    {
	    if (IsGrounded()) currentJumpForce = jumpForce;
    }
    
    public void ResetPosition()
    {
	    entityRigidbody.position = new Vector3(0, 0, 0);
    }
}

