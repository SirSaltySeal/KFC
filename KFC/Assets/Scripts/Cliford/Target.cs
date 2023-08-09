/*
 * Author: Tanucan Cliford Baguio
 * Date: 2/08/2023
 * Description: Enemy Health
 */
using UnityEngine;

public class Target : MonoBehaviour
{
    public Quests quest;
    public float health = 100f;
    public int ID { get;set; }

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
        if(quest.isActive)
        {
            quest.goal.EnemyKilled();
            if (quest.goal.IsReached())
            {
                quest.Complete();
            }
        }
    }
}
