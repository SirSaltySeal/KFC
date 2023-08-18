using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHealth;
    [SerializeField]
    private float CurrentHealth;

    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void playerTakeDamage(float Amount)
    {
        CurrentHealth -= Amount;
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
            CurrentHealth = MaxHealth;
        }
    }
}
