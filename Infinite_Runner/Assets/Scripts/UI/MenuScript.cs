using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public void PlayGame()
    {
        //THIS LOADS THE GAME SCENE - USING A DYNAMIC REFERENCE TO ACHEIEVE, SINCE GAME SCENE IS 2 SCENES ABOVE THE MENU (CURRENT) SCENE
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void LoadSettings()
    {
        //SAME LOGIC AS PLAYGAME(), BUT THIS IS LOADING THE SETTINGS MENU
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
