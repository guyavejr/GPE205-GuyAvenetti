using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called oncer per frame
    public override void Update()
    {
        base.Start();
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
}
