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
        Debug.Log(source.name + "did" + amount + "damage to" + gameObject.name);
        Debug.Log(currentHealth);
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (currentHealth <= 0)
        {
            Die(source);
        }
    }

    public void Heal(float amount, Pawn source)
    {
        currentHealth = currentHealth + amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log(source.name + "did" + amount + "heal to" + gameObject.name);
        Debug.Log(currentHealth);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
