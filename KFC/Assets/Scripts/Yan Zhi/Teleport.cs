using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject thePlayer;

    
    /// <summary>
    /// Find the player, prefab player doesn't detect.
    /// </summary>
    private void Start()
    {
        thePlayer = FindObjectOfType<Player>().gameObject;
    }
    /// Touch and teleport to teleporTarget
    private void OnTriggerEnter(Collider other)
    {
        //GetComponent<AudioSource>().Play();
        thePlayer.transform.position = teleportTarget.transform.position;
    }
}
