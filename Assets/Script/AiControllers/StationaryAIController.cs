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

                Debug.Log(target);
                break;

            case AIState.Idle:
                //do work
                DoIdleState();
                //check for transition
                if (CanSee(target))
                {
                    ChangeState(AIState.StationaryAttack);
                }
                break;

            case AIState.StationaryAttack:
                DoAttackState();
                if (CanSee(target))
                {
                    Debug.Log("cansee and attacking");
                    ChangeState(AIState.StationaryAttack);
                }
                break;




        }
    }
}
