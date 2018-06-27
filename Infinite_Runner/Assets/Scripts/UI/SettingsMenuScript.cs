using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenuScript : MonoBehaviour {

    public void Back()
    {
        //LOADING THE MENU SCENE, DYNAMICALLY
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
