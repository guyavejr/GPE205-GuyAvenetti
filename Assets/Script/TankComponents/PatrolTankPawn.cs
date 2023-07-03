using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolTankPawn : TankPawn
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

            //currentHealth = currentHealth + amount;
            //currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            //Debug.Log(source.name + "did" + amount + "heal to" + gameObject.name);
            //Debug.Log(currentHealth);

    public override void RotateTowards(Vector3 targetPosition)
    {
        //find vector to target
        Vector3 vectorToTarget = targetPosition - transform.position;
        //find the rotation 
        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);
        //rotate at turn speed
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    public override void MoveSpeedBoost(float amount, Pawn source)
    {
        moveSpeed = moveSpeed + amount;
        moveSpeed = Mathf.Clamp(moveSpeed, moveSpeed, maxMoveSpeed);
        
    }
}
