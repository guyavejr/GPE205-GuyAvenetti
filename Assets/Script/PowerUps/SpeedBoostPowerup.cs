using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpeedBoost : PowerUp
{
    public float speedToAdd;
    
 

    public override void Apply(PowerupManager target)
    {
        //Apply Health changes 
        TankPawn targetmoveSpeed = target.GetComponent<TankPawn>();
        if (targetmoveSpeed != null)
        {
            targetmoveSpeed.MoveSpeedBoost(speedToAdd, target.GetComponent<TankPawn>());
        }
        
    }

    public override void Remove(PowerupManager target)
    {
        TankPawn targetmoveSpeed = target.GetComponent<TankPawn>();
        if (targetmoveSpeed != null)
        {
            targetmoveSpeed.MoveSpeedBoost(-speedToAdd, target.GetComponent<TankPawn>());
        }
    }
}
