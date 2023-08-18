/*
 * Author: Tanucan Cliford Baguio
 * Date: 2/08/2023
 * Description: Enemy Health
 */
using TMPro;
using UnityEngine;

public class Target : MonoBehaviour
{
    //public Quests quest;
    public float health;
    public int score = 0;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
            score++;
            Debug.Log(score);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
