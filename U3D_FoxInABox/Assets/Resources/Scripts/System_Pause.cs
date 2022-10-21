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
        foreach (var player in FindObjectsOfType<Entity_Input_Player>())
        {
            player.canMove = false;
        }
        foreach (var player in FindObjectsOfType<Player_Turning>())
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
        foreach (var player in FindObjectsOfType<Player_Turning>())
        {
            player.canMove = true;
        }
    }
}