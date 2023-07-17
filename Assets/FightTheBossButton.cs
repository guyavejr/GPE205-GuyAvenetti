using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightTheBossButton : MonoBehaviour
{
    public void FightTheboss()
    {
        GameManager.instance.ContinueToTheBossWorld();
    }
}
