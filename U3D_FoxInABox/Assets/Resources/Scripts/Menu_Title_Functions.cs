//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: 
// Applied to:  
// Notes: 
//
//=============================================================================

using System;
using TMPro;
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
    public void SetUsername(TMP_InputField usernameField)
    {
        if (usernameField.text == "") PlayerPrefs.SetString("NetworkClientUsername", "NetPlayer");
        else PlayerPrefs.SetString("NetworkClientUsername", usernameField.text);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

