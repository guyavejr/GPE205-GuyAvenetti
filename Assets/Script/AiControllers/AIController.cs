using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIController : Controller
{
    public GameObject target;
    
    public enum AIState
    {
        TargetPlayer, Idle, Chase, Attack, Flee, Patrol, StationaryAttack, StationaryPatrol, Alerting, IdleAggressor
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
    //public Transform[] alertwaypoints;
    //public int currentalertWaypoint = 0;

    //Start 
    public override void Start()
    {
        base.Update();
        

    }
    public override void Update()
    {
        base.Update();   

    }

    public abstract void MakeDecisions();
   

    public override void ProcessInputs()
    {
        
    }
    public virtual void Seek(GameObject target)
    {
        pawn.RotateTowards(target.transform.position);

        pawn.MoveForward();

    }
    public virtual void Seek(Vector3 targetPosition)
    {
        pawn.RotateTowards(targetPosition);

        pawn.MoveForward();
    }
    public virtual void Seek(Transform targetTransform)
    {
        Seek(targetTransform.position);
    }
    public virtual void Seek(Pawn targetPawn)
    {
        Seek(targetPawn.transform);
    }


    public virtual void Shoot()
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
        Seek(target);
        
        Shoot();   
    }

    protected virtual void DoAlertState()
    {
        Alert();

        RestartPatrol();
    }
    protected virtual void DoPatrolState()
    {
        Patrol();
    }

    protected virtual void DoChooseTargetState()
    {
        TargetPlayer();
    }

    protected virtual void DoStationaryAttackState()
    {
        StationarySeek(target);

        Shoot();
    }

    protected virtual void DoStationaryPatrol()
    {
        StationarySeek(target);
    }

    protected virtual void StationarySeek(GameObject target)
    {
        pawn.RotateTowards(target.transform.position);
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

    protected virtual bool IsDistanceLessThan(GameObject target, float distance)
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

    protected virtual void Patrol()
    {
        if (waypoints.Length > currentWaypoint)
        {
            Seek(waypoints[currentWaypoint]);
            

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
    protected virtual void RestartPatrol()
    {
        currentWaypoint = 0;
    }

    protected virtual void Alert()
    {
        
        TargetNearestAggressor();
        
        Seek(target);
    }

    protected virtual void DoIdleAggressor()
    {
        TargetNearestPatrol();
    }

    public float hearingDistance;
    public bool CanHear(GameObject target)
    {
        NoiseMaker noiseMaker = target.GetComponent<NoiseMaker>();
        
        if (noiseMaker == null)
        {
            
            return false;
        }
        if (noiseMaker.volumeDistance <= 0)
        {
            
            return false;
        }

        float totalDistance = noiseMaker.volumeDistance + hearingDistance;

        if (Vector3.Distance(pawn.transform.position, target.transform.position) <= totalDistance)
        {
            
            return true;
        }
        else
        {
            return false;
        }
    }
    // Field of View
    public virtual bool CanSee(GameObject target)
    {
        Vector3 agentToTargetVector = target.transform.position - transform.position;
        float angleToTarget = Vector3.Angle(agentToTargetVector, pawn.transform.forward);
        if (angleToTarget < fieldOfView)
        {
            
            return true;
        }
        else
        {
            return false;
        }
    }

    //Line of Sight  

    //Find Target
    public virtual void TargetPlayer()
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
            else
            {
                DoIdleState();
            }
        }
    }
    //do we have a target
    protected virtual bool IsHasTarget()
    {
        return (target != null);
    }
    //AIHelper
    protected void TargetNearestTank()
    {
        //list of pawns
        Pawn[] allTanks = FindObjectsOfType<Pawn>();
        Pawn closestTank = allTanks[1];
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

    protected void TargetNearestAggressor()
    {
        AggressorTankPawn[] aggressor = FindObjectsOfType<AggressorTankPawn>();
        
        AggressorTankPawn aggressorEnemyPrefab = aggressor[0];
        float aggressorEnemyPrefabDistance = Vector3.Distance(pawn.transform.position, aggressorEnemyPrefab.transform.position);
        foreach (AggressorTankPawn tank in aggressor)
        {
            if (Vector3.Distance(pawn.transform.position, tank.transform.position) <= aggressorEnemyPrefabDistance)
            {
                aggressorEnemyPrefab = tank;
                aggressorEnemyPrefabDistance = Vector3.Distance(pawn.transform.position, aggressorEnemyPrefab.transform.position);
            }
        }
        target = aggressorEnemyPrefab.gameObject;
    }
    protected void TargetNearestPatrol()
    {
        PatrolTankPawn[] patrol = FindObjectsOfType<PatrolTankPawn>();

        PatrolTankPawn patrolEnemyPrefab = patrol[0];
        float patrolEnemyPawnDistance = Vector3.Distance(pawn.transform.position, patrolEnemyPrefab.transform.position);
        foreach (PatrolTankPawn tank in patrol)
        {
            if (Vector3.Distance(pawn.transform.position, tank.transform.position) <= patrolEnemyPawnDistance)
            {
                patrolEnemyPrefab = tank;
                patrolEnemyPawnDistance = Vector3.Distance(pawn.transform.position, patrolEnemyPrefab.transform.position);
            }
        }
        target = patrolEnemyPrefab.gameObject;
    }

    public virtual void ChangeState ( AIState newState)
    {
        // change the current state 
        currentState = newState;
        //dave the time when we change states
        lastStateChangeTime = Time.time;
    }
}