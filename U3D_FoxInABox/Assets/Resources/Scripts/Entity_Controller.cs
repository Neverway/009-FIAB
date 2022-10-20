//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// 
// Purpose: 
// Applied to: 
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
    public float speed = 1300;
    
    [Header("Jumping")]
    public float jumpForce = 5000;
    public LayerMask groundLayers;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public float maxDistance = 0.1f;

    [Header("Drag")]
    public float groundDrag = 4;
    public float airDrag = 0.2f;
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
	    return (Physics.SphereCast(groundCheck.position,groundCheckRadius,Vector3.down,out var hit,maxDistance,groundLayers));
    }


    //=-----------------=
    // External Functions
    //=-----------------=
    
    public void Jump()
    {
	    if (IsGrounded()) currentJumpForce = jumpForce;
    }
}

