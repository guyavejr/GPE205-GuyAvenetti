using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginPlay : MonoBehaviour
{
    
    public void BegginPlayButton()
    {
        if (GameStateMachine.instance != null)
        {
            GameStateMachine.instance.GamePlay(gameObject);
        }
    }
}
