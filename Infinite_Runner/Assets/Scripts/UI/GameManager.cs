using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //-----BEGIN TIMER CODE-----\\   
    public Text timerText;
    private float startTime;
    //------END TIMER CODE------\\   


    //-----BEGIN PAUSE CODE-----\\
    public static bool IsGamePaused = false;

    public GameObject PauseMenuUI;
    //-------END PAUSE CODE-------\\


    //-----BEGIN GAME OVER CODE-----\\ 
    public GameObject gameOverUI;
    //------END GAME OVER CODE------\\ 




    // Use this for initialization
    void Start () {

        //-----BEGIN TIMER CODE-----\\   
        startTime = Time.time;
        //------END TIMER CODE------\\ 
    }

    // Update is called once per frame
    void Update () {

        //-----BEGIN TIMER CODE-----\\   
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f1");

        timerText.text = minutes + ":" + seconds;
        //------END TIMER CODE------\\ 
    }

    //-----BEGIN GAME OVER CODE-----\\ 
    public void EndGame()
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }
    //------END GAME OVER CODE------\\ 



    //-----BEGIN PAUSE GAME-----\\
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
    }
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = true;
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    public void LoadSettings()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    //-------END PAUSE GAME-------\\
}
