//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// [G2]
// Purpose: 
//          Give functionality to the connect to game and quit game title buttons
// Applied to:  
//          The root of the title screen ui element
// Notes: 
//
//=============================================================================

using UnityEngine;

public class Menu_Title_Functions : MonoBehaviour
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
    private System_SceneManager sceneManager;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
        sceneManager = FindObjectOfType<System_SceneManager>();
    }


    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public void LoadLobby()
    {
        sceneManager.LoadScene("Lobby", 0.5f);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}

