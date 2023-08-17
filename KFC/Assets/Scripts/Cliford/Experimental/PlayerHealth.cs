using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene("DeathMenu");
        }
    }
}
