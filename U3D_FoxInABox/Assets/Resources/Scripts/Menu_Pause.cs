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
using UnityEditor;
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
	    if (menuManager.menuOpen) return;
	    Cursor.lockState = CursorLockMode.None;
	    transform.GetChild(0).gameObject.SetActive(true);
	    active = true;
	    menuManager.menuOpen = true;
    }
    
    public void CloseMenu()
    {
	    Cursor.lockState = CursorLockMode.Locked;
	    transform.GetChild(0).gameObject.SetActive(false);
	    active = false;
	    menuManager.menuOpen = false;
    }
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

