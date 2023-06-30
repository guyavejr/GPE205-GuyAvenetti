using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : Mover
{
    //RigidBody Component
    private Rigidbody rb;

    //start
    public override void Start()
    {
        //get rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    public override void Move(Vector3 direction, float speed)
    {
        rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
    }

    public override void Rotate(float speed)
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
