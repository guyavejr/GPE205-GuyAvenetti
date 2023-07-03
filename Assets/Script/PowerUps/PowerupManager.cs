using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public Pawn owner;

    public void Add (PowerUp poweruptoAdd)
    {
        //Add
        poweruptoAdd.Apply(this);
    }

    public void Remove(PowerUp powerupToRemove)
    {
        powerupToRemove.Remove(this);
    } 
}
