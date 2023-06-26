using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    //Variable for move speed
    public float moveSpeed;
    //Variable for turn speed
    public float turnSpeed;
    //Variable for mover
    public Mover mover;
    //Variable for shooter
    public Shooter shooter;
    //variable rate of fire
    public float fireRate;

    public GameObject BulletPrefab;

    public float fireForce;

    public float damageDone;

    public float BulletLifespan;

    
    // Start is called before the first frame update
    public virtual void Start()
    {
        mover = GetComponent<Mover>();
        shooter = GetComponent<Shooter>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public abstract void MoveForward();
    public abstract void MoveBackwards();
    public abstract void RotateClockwise();
    public abstract void RotateCounterClockwise();
    public abstract void Shoot();
    
    public abstract void RotateTowards(Vector3 targetPosition);

}
