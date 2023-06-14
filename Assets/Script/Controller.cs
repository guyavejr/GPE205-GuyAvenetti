using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    //Variable to hold our Pawn
    public Pawn pawn;

    //Start is called before the first frame update
    public virtual void Start()
    {

    }
    //update is called once per frame
    public virtual void Update()
    {

    }
    //child classes must override the way they process inputs 
    public abstract void ProcessInputs();
}
