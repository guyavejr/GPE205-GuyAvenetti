using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerController : Controller
{
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardsKey;
    public KeyCode rotateCounterClockwiseKey;
    public KeyCode rotateClockwiseKey;
    public KeyCode shootKey;
    public KeyCode generateMapKey;

    //start
    public override void Start()
    {
        if (GameManager.instance != null)
        {
            if (GameManager.instance.players != null)
            {
                GameManager.instance.players.Add(this);
            }
        }
        base.Start();
    }

    public void OnDestroy()
    {
        if(GameManager.instance != null)
        {
            if (GameManager.instance.players != null)
            {
                GameManager.instance.players.Remove(this);
            }
        }
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

        if (Input.GetKeyDown(shootKey))
        {
            pawn.Shoot();
        }
    }


}
