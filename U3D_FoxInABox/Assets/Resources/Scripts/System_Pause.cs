//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// 
// Purpose: 
// Applied to: 
// Editor script: 
// Notes: 
//
//=============================================================================

using UnityEngine;
using UnityEngine.UI;

public class System_Pause : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=


    //=-----------------=
    // Private Variables
    //=-----------------=
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=


    //=-----------------=
    // Mono Functions
    //=-----------------=
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public void PauseGame()
    {
        if (FindObjectOfType<Entity_Input_Player>()) FindObjectOfType<Entity_Input_Player>().canMove = false;
        if (FindObjectOfType<Player_Turning>()) FindObjectOfType<Player_Turning>().canMove = false;
    }
    
    public void UnpauseGame()
    {
        if (FindObjectOfType<Entity_Input_Player>()) FindObjectOfType<Entity_Input_Player>().canMove = true;
        if (FindObjectOfType<Player_Turning>()) FindObjectOfType<Player_Turning>().canMove = true;
    }
}