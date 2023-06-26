using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : Controller
{
    public GameObject target;
    
    public enum AIState
    {
        TargetPlayer, Idle, Chase, Attack, Flee, Patrol,
    };
    
    public AIState currentState;

    public float lastStateChangeTime;

    private float timeUntilNextShot;

    public float fleeDistance;

    public float fieldOfView;

    public float maxViewDistance;

    Ray ray;

    public Transform[] waypoints;
    public float waypointsStopDistance;
    public int currentWaypoint = 0;

    //Start 
    public override void Start()
    {
        base.Update();
        

    }
    public override void Update()
    {
        base.Update();
        MakeDecisions();
        

    }

    public void MakeDecisions()
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
                if (!IsDistanceLessThan(target, 30))
                {
                    ChangeState(AIState.Chase);
                }
                if (!IsDistanceLessThan(target, 35))
                {
                    ChangeState(AIState.Patrol);
                }
                if (IsDistanceLessThan(target, 20))
                {
                    ChangeState(AIState.Attack);
                }
                break;

            case AIState.Chase:
                //do work
                DoChaseState();
                //check transitions
                if (!IsDistanceLessThan(target, 35))
                {
                    ChangeState(AIState.Idle);
                }
                if (IsDistanceLessThan(target, 20))
                {
                    ChangeState(AIState.Attack);
                }
                break;

            case AIState.Attack:
                DoAttackState();
                if (IsDistanceLessThan(target, 20))
                {
                    ChangeState(AIState.Attack);
                }
                if (IsDistanceLessThan(target, 5))
                {
                    ChangeState(AIState.Flee);
                }
                if (!IsDistanceLessThan(target, 30))
                {
                    ChangeState(AIState.Chase);
                }
                break;

            case AIState.Flee:
                Flee();
                if (IsDistanceLessThan(target, 5))
                {
                    ChangeState(AIState.Flee);
                }
                if (!IsDistanceLessThan(target, fleeDistance))
                {
                    ChangeState(AIState.Chase);
                }
                break;

            case AIState.Patrol:
                DoPatrolState();
                if(!IsDistanceLessThan(target, 35))
                {
                    ChangeState(AIState.Patrol);
                }
                if (IsDistanceLessThan(target, 35))
                {
                    ChangeState(AIState.Idle);
                }
                if (CanHear(target))
                {
                    ChangeState(AIState.Chase);
                }
                break;
        }
    }

    public override void ProcessInputs()
    {
        
    }
    public void Seek(GameObject target)
    {
        pawn.RotateTowards(target.transform.position);

        pawn.MoveForward();
    }
    public void Seek(Vector3 targetPosition)
    {
        pawn.RotateTowards(targetPosition);

        pawn.MoveForward();
    }
    public void Seek(Transform targetTransform)
    {
        Seek(targetTransform.position);
    }
    public void Seek(Pawn targetPawn)
    {
        Seek(targetPawn.transform);
    }


    public void Shoot()
    {
        //tell the pawn to shoot
        pawn.Shoot();
    }

    protected virtual void DoChaseState()
    {
        Seek(target);
    }

    protected virtual void DoIdleState()
    {
        //DO Nothing
    }

    protected virtual void DoAttackState()
    {
        //Chase
        Seek(target);
        //shoot
        Shoot();
    }

    protected virtual void DoPatrolState()
    {
        Patrol();
    }

    protected virtual void DoChooseTargetState()
    {
        TargetPlayer();
    }

    protected void Flee()
    {
        //USING VECTOR3
        //find vector to our target
        Vector3 vectorToTarget = target.transform.position - pawn.transform.position;
        //find vector away * -1 
        Vector3 vectorAwayFromTarget = -vectorToTarget;
        //find the vector we would travel donw in order to flee
        Vector3 fleeVector = vectorAwayFromTarget.normalized * fleeDistance;
        //seek the piont that is fleevector away 

        //USING Precentage
        //distance to the play 
        //float targetDistance = Vector3.Distance(target.transform.position, pawn.transform.position);
        //float percentOfFleeDistnace = targetDistance / fleeDistance;
        //percentOfFleeDistnace = Mathf.Clamp01(percentOfFleeDistnace);
        //float flippedPercentOfFleeDistnace = 1 - percentOfFleeDistnace;

        Seek(pawn.transform.position + fleeVector);
    }

    protected bool IsDistanceLessThan(GameObject target, float distance)
    {
        if (Vector3.Distance (pawn.transform.position, target.transform.position) < distance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected void Patrol()
    {
        if (waypoints.Length > currentWaypoint)
        {
            Seek(waypoints[currentWaypoint]);
            Debug.Log(currentWaypoint);

            if(Vector3.Distance(pawn.transform.position, waypoints[currentWaypoint].position) < waypointsStopDistance)
            {
                currentWaypoint++;
            }
        }
        else
        {
            RestartPatrol();
        }
    }
    protected void RestartPatrol()
    {
        currentWaypoint = 0;
    }

    public float hearingDistance;
    public bool CanHear(GameObject target)
    {
        NoiseMaker noiseMaker = target.GetComponent<NoiseMaker>();
        
        if (noiseMaker == null)
        {
            Debug.Log("Cannothear");
            return false;
        }
        if (noiseMaker.volumeDistance <= 0)
        {
            Debug.Log("Cannothear");
            return false;
        }

        float totalDistance = noiseMaker.volumeDistance + hearingDistance;

        if (Vector3.Distance(pawn.transform.position, target.transform.position) <= totalDistance)
        {
            Debug.Log("ICanHearYou");
            return true;
        }
        else
        {
            Debug.Log("Cannothear");
            return false;
        }
    }
    // Field of View
    public bool CanSee(GameObject target)
    {
        Vector3 agentToTargetVector = target.transform.position - transform.position;
        float angleToTarget = Vector3.Angle(agentToTargetVector, pawn.transform.forward);
        if (angleToTarget < fieldOfView)
        {
            Debug.Log("ICanSeeYou");
            return true;
        }
        else
        {
            return false;
        }
    }

    //Line of Sight  

    //Find Target
    public void TargetPlayer()
    {
        if (GameManager.instance != null)
        {
            if (GameManager.instance.players != null)
            {
                if (GameManager.instance.players.Count > 0)
                {
                    target = GameManager.instance.players[0].pawn.gameObject;
                }
            }
        }
    }
    //do we have a target
    protected bool IsHasTarget()
    {
        return (target != null);
    }
    //AIHelper
    protected void TargetNearestTank()
    {
        //list of pawns
        Pawn[] allTanks = FindObjectsOfType<Pawn>();
        Pawn closestTank = allTanks[0];
        float closestTankDistance = Vector3.Distance(pawn.transform.position, closestTank.transform.position);
        foreach (Pawn tank in allTanks)
        {
            if (Vector3.Distance(pawn.transform.position, tank.transform.position) <= closestTankDistance)
            {
                closestTank = tank;
                closestTankDistance = Vector3.Distance(pawn.transform.position, closestTank.transform.position);
            }
        }
        target = closestTank.gameObject;
    }
    public virtual void ChangeState ( AIState newState)
    {
        // change the current state 
        currentState = newState;
        //dave the time when we change states
        lastStateChangeTime = Time.time;
    }
}