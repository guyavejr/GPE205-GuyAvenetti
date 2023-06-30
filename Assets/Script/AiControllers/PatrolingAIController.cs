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

                ChangeState(AIState.Idle);
;
                break;

            case AIState.Idle:
                DoIdleState();

                ChangeState(AIState.Patrol);
                Debug.Log("patroling");
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

                if (Vector3.Distance(pawn.transform.position, alertwaypoints[currentalertWaypoint].position) < waypointsStopDistance)
                {
                    Debug.Log("backtopatrol");
                    ChangeState(AIState.Patrol);
                }

                break;

               


        }
    }
}