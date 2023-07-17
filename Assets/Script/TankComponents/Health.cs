using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public GameObject pawn;
    public Transform respawnPoint;
    public Image healthBar;
  
    
    

    

    public void TakeDamage (float amount, Pawn source)
    {
        currentHealth = currentHealth - amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (currentHealth <= 0)
        {
            Respawn(source);
            LoseLife();
        }
    }
    
    public void Heal(float amount, Pawn source)
    {
        currentHealth = currentHealth + amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public void Respawn(Pawn sourse)
    {
        if (respawnPoint != null)
        {
            pawn.transform.position = respawnPoint.position;
            currentHealth = maxHealth;
        }
        else
        {
            Die(sourse);
        }
    }

    public void Die(Pawn source)
    {
        Destroy(gameObject);
        if (GameManager.instance.mapGenerator != null)
        {
            GameManager.instance.AddPoint();
        }
    }
    private void Update()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    public void LoseLife()
    {
        if (respawnPoint != null)
        {
            if (GameManager.instance != null)
            {
                Debug.Log("loselife");
                GameManager.instance.LoseLife();
            }
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
        //set health to max 
        currentHealth = maxHealth;
        
    }
}
