using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgresserAiController : AIController
{
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
            case AIState.Idle:
                ChangeState(AIState.Idle);
                if (CanHear(target))
                {
                    ChangeState(AIState.TargetPlayer);
                }
                break;
            case AIState.TargetPlayer:
                DoChooseTargetState();

                ChangeState(AIState.Chase);
                break;

            case AIState.Chase:
                DoChaseState();
                if (IsDistanceLessThan(target, 15))
                {
                    ChangeState(AIState.Attack);
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
        }
    }
}
