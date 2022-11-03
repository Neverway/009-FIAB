//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// [G2]
// Purpose: 
//          Freeze entities when the a pausing menu is open
// Applied to: 
//          The system manager
// Notes: 
//
//=============================================================================

using UnityEngine;

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
        foreach (var player in FindObjectsOfType<Entity_Input_Player>())
        {
            player.canMove = false;
        }
        foreach (var player in FindObjectsOfType<Entity_Input_Player_Rotation>())
        {
            player.canMove = false;
        }
    }
    
    public void UnpauseGame()
    {
        foreach (var player in FindObjectsOfType<Entity_Input_Player>())
        {
            player.canMove = true;
        }
        foreach (var player in FindObjectsOfType<Entity_Input_Player_Rotation>())
        {
            player.canMove = true;
        }
    }
}