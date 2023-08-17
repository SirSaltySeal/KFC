using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PausePanel;
    public static bool isPaused = false;
    PlayerLook script;


    // Update is called once per frame
    void Update()
    {
        script=FindObjectOfType<PlayerLook>();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ContinueGame();
                script.enabled = true;
            }
            else
            {
                PauseGame(); 
                script.enabled = false;
            }
        }

    }

    public void PauseGame()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;

    }

    public void ContinueGame()
    {
        PausePanel.SetActive(false); 
        Time.timeScale = 1;
        isPaused = false;
    }
}
