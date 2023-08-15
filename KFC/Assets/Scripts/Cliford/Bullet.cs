using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage;
    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.gameObject.GetComponent<PlayerHealth>().playerTakeDamage(Damage);
            Debug.Log(gameObject);
        }
    }
}