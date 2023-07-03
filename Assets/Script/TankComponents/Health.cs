using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;

    public void TakeDamage (float amount, Pawn source)
    {
        currentHealth = currentHealth - amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (currentHealth <= 0)
        {
            Die (source);
        }
    }

    public void Heal(float amount, Pawn source)
    {
        currentHealth = currentHealth + amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public void Die(Pawn source)
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //set health to max 
        currentHealth = maxHealth;
    }
}
