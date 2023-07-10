using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandbyAiController : AIController
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
                TargetPlayer();
                ChangeState(AIState.Idle);
                break;
            case AIState.Idle:
                DoIdleState();
                if (CanHear(target))
                {
                    ChangeState(AIState.Chase);
                }
                if (CanSee(target))
                {
                    ChangeState(AIState.Attack);
                }
                break;
            case AIState.Chase:
                DoChaseState();
                if (CanSee(target))
                {
                    ChangeState(AIState.Attack);
                }
                if (!CanHear(target))
                {
                    ChangeState(AIState.Idle);
                }
                break;
            case AIState.Attack:
                DoAttackState();
                if (IsDistanceLessThan(target, 5))
                {
                    ChangeState(AIState.Flee);
                }
                if (!CanSee(target))
                {
                    ChangeState(AIState.Chase);
                }
                break;

            case AIState.Flee:
                Flee();
                if (CanHear(target))
                {
                    if (!IsDistanceLessThan(target, 10))
                    {
                        ChangeState(AIState.Chase);
                    }
                }
                break;
        }
    }
}
