using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public static bool HelpOn = false;
    public GameObject HelpMenuUI;
    public string firstLevel;
    // Start is called before the first frame update
    

    /// <summary>
    /// The play button click will move to the next scene
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene(firstLevel);
    }
    /// <summary>
    /// Menu pop out and close
    /// </summary>
    public void HelpMenuDone()
    {
        if (HelpOn)
        {
            HelpMenuOff();
        }
        else
        {
            HelpMenuOn();
        }
    }
    /// <summary>
    /// Menu On
    /// </summary>
    public void HelpMenuOn()
    {
        HelpMenuUI.SetActive(true);
    }
    /// <summary>
    /// Menu close
    /// </summary>
    public void HelpMenuOff()
    {
        HelpMenuUI.SetActive(false);
    }
}
