using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressStart_Main_Menu : MonoBehaviour
{
    /// <summary>
    /// Just a simple scene to Enter the game.
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// TODO: Change everything to options menu
    /// </summary>
    void Update()
    {
        if(Input.GetKeyDown("return")){
            SceneManager.LoadScene("InGameSceneExample");
        }
    }
}
