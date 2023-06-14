using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardsKey;
    public KeyCode rotateCounterClockwiseKey;
    public KeyCode rotateClockwiseKey;

    //start
    public override void Start()
    {
        base.Start();
    }

    //update
    public override void Update()
    {
        //Process keyboard inputs
        ProcessInputs();

        //update from parent class
        base.Update();
    }

    public override void ProcessInputs()
    {
        if (Input.GetKey(moveForwardKey))
        {
            pawn.MoveForward();
        }

        if (Input.GetKey(moveBackwardsKey))
        {
            pawn.MoveBackwards();
        }

        if (Input.GetKey(rotateClockwiseKey))
        {
            pawn.RotateClockwise();
        }

        if (Input.GetKey(rotateCounterClockwiseKey))
        {
            pawn.RotateCounterClockwise();
        }
    }
}
