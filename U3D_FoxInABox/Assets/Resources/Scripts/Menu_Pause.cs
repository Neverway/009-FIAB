//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: 
//			Allow the player to open and close the pause menu
// Applied to: 
//			The root of the pause menu UI element
// Notes: 
//
//=============================================================================

using UnityEngine;

public class Menu_Pause : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=


    //=-----------------=
    // Private Variables
    //=-----------------=
    private bool active;
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    private System_MenuManager menuManager;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
	    menuManager = FindObjectOfType<System_MenuManager>();
    }

    private void Update()
    {
	    if (!Input.GetKeyDown(KeyCode.Escape)) return;
	    if (!active) OpenMenu();
	    else CloseMenu();
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    private void OpenMenu()
    {
	    // Exit if another menu is already open
	    if (menuManager.menuOpen) return;
	    // Unlock mouse
	    Cursor.lockState = CursorLockMode.None;
	    // Show menu
	    transform.GetChild(0).gameObject.SetActive(true);
	    // Set menu state to open
	    active = true;
	    menuManager.menuOpen = true;
    }
    
    public void CloseMenu()
    {
	    // Lock mouse
	    Cursor.lockState = CursorLockMode.Locked;
	    // Hide menu
	    transform.GetChild(0).gameObject.SetActive(false);
	    // Set menu state to closed
	    active = false;
	    menuManager.menuOpen = false;
    }
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

