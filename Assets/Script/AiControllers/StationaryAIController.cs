using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryAIController : AIController
{
    public override void TargetPlayer()
    {
        base.TargetPlayer();
    }

    public override void Start()
    {
        base.Update();
    }
    public override void Update()
    {
        base.Update();
        MakeDecisions();
        
        
    }
    public override void MakeDecisions()
    {
        switch (currentState)
        {
            case AIState.TargetPlayer:
                DoChooseTargetState();
                ChangeState(AIState.Idle);
                break;
            case AIState.Idle:
                DoStationaryPatrol();
                if (IsDistanceLessThan(target, 25))
                {
                    ChangeState(AIState.StationaryAttack);
                }
                break;
            case AIState.StationaryAttack:
                DoAttackState();
                if (CanSee(target))
                {
                    ChangeState(AIState.StationaryAttack);
                }
                break;
        }
    }
}
