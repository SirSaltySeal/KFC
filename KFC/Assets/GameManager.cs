using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject playerPrefab;
    private Player activePlayer;

    public static GameManager instance;
    //private void Awake()
    //{
    //    DontDestroyOnLoad(gameObject);
    //    SceneManager.activeSceneChanged += SpawnPlayerOnLoad;
    //}
    //void SpawnPlayerOnLoad(Scene prev, Scene next)
    //{
    //    Debug.Log("Entering scene is : " + next.buildIndex);
    //    if (next.buildIndex == 3)
    //    {
    //        if (activePlayer != null)
    //            Destroy(activePlayer);
    //        activePlayer = null;
    //    }
    //    else
    //    {
    //        if (activePlayer = null)
    //        {
    //            GameObject player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
    //            activePlayer = player.GetComponent<move>();
    //        }
    //    }
    //}

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.activeSceneChanged += SpawnPlayerOnScreenLoad;

            instance = this;
        }
    }
    /// <summary>
    /// Spawn player in scene
    /// </summary>
    private void SpawnPlayerOnScreenLoad(Scene curScene, Scene next)
    {
        spawn spawnpoint = FindObjectOfType<spawn>();
        if (activePlayer == null)
        {
            GameObject newPlayer = Instantiate(playerPrefab, spawnpoint.transform.position, Quaternion.identity);
            activePlayer = newPlayer.GetComponent<Player>();
        }
        else
        {
            activePlayer.transform.position = spawnpoint.transform.position;
        }
    }
}
