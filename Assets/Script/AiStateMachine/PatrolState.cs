using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    public PatrolState patrolState;
    public bool canHearPlayer;
    public override State RunCurrentState()
    {
        if (canHearPlayer)
        {
            return patrolState;
        }
        else
        {
            return this;
        }
    }
}
