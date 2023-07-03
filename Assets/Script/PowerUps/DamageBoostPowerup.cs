using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DamageBoost : PowerUp
{
    public float damageToAdd;
    

    public override void Apply(PowerupManager target)
    {
        //Apply Health changes 
        TankPawn targetdamageDone = target.GetComponent<TankPawn>();
        if (targetdamageDone != null)
        {
            targetdamageDone.DamageBoost(damageToAdd, target.GetComponent<TankPawn>());
        }
    }

    public override void Remove(PowerupManager target)
    {
        
    }
}
