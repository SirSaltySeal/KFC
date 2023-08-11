using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    // Update is called once per frame

    /// <summary>
    /// pressing Escape Key can trigger pause menu
    /// </summary>
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused )
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    /// <summary>
    /// Pause menu pop out and close
    /// </summary>
    public void PauseMenuDone() 
    {
        if (GameIsPaused )
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
    /// <summary>
    /// resume game
    /// </summary>
    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    /// <summary>
    /// Pause and freeze the Game
    /// </summary>
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    /// <summary>
    /// Player click quit button and it will go back to the 1st scene which is the menu
    /// </summary>
    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
}
