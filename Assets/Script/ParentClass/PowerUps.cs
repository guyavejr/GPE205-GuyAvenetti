using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp
{
    public abstract void Apply(PowerupManager target);
    public abstract void Remove(PowerupManager target);
}
