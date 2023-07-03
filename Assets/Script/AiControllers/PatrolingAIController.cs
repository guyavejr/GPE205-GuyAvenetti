using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolingAIController : AIController
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
                ChangeState(AIState.Patrol);
                break;

            case AIState.Patrol:
                DoPatrolState();
                if (CanHear(target))
                {
                    ChangeState(AIState.Alerting);
                }
                break;

            case AIState.Alerting:
                DoAlertState();
                if (IsDistanceLessThan(target, 5))
                {
                    ChangeState(AIState.TargetPlayer);
                }
                break;

               


        }
    }
}