using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HealthPowerup : PowerUp
{
    public float healthToAdd;
    

    public override void Apply(PowerupManager target)
    {
        //Apply Health changes 
        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.Heal(healthToAdd, target.GetComponent<Pawn>());
        }
    }

    public override void Remove(PowerupManager target)
    {
        
    }
}
