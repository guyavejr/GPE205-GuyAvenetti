using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostPickup : MonoBehaviour
{
    public SpeedBoost powerup;
    public void OnTriggerEnter(Collider other)
    {
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();
        if (powerupManager != null)
        {
            powerupManager.Add(powerup);
            
            Destroy(gameObject);
        }
    }
}
