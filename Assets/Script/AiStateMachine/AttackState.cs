using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public AttackState attackState;
    public bool isInAttackRange;
    public override State RunCurrentState()
    {
        if (isInAttackRange)
        {
            return attackState;
        }
        else
        {
            Debug.Log("I Have Attacked!");
            return this;
        }
        

    }
}
