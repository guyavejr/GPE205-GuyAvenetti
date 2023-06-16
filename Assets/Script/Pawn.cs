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
    
    // Start is called before the first frame update
    public virtual void Start()
    {
        mover = GetComponent<Mover>(); 
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public abstract void MoveForward();
    public abstract void MoveBackwards();
    public abstract void RotateClockwise();
    public abstract void RotateCounterClockwise();
}