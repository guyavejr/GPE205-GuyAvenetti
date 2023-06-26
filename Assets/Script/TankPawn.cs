using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{

    private float timeUntilNextEvent;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        timeUntilNextEvent = fireRate;
        
    }

    // Update is called oncer per frame
    public override void Update()
    {
        base.Start();
        timeUntilNextEvent -= Time.deltaTime;
        if (timeUntilNextEvent <= 0)
        {
            timeUntilNextEvent = fireRate;
        }
    }

    public override void MoveForward()
    {
        mover.Move(transform.position, moveSpeed);
    }
    public override void MoveBackwards()
    {
        mover.Move(transform.position, -moveSpeed); 
    }

    public override void RotateClockwise()
    {
        mover.Rotate(turnSpeed);
    }

    public override void RotateCounterClockwise()
    {
        mover.Rotate(-turnSpeed);
    }

    public override void Shoot()
    {
        if (timeUntilNextEvent >= fireRate)
        {
            shooter.Shoot(BulletPrefab, fireForce, damageDone, BulletLifespan, fireRate);
        }
        
    }

    public override void RotateTowards(Vector3 targetPosition)
    {
        //find vector to target
        Vector3 vectorToTarget = targetPosition - transform.position;
        //find the rotation 
        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);
        //rotate at turn speed
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }
}
