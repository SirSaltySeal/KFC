/*
 * Author: Tanucan Cliford Baguio
 * Date: 2/08/2023
 * Description: Enemy Health
 */
using UnityEngine;

public class BasicEnemyHP : MonoBehaviour
{
    public float health = 20f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
