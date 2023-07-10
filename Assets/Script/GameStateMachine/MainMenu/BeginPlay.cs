using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginPlay : MonoBehaviour
{
    public void BegginPlayButton()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.gameStateMachine.GamePlay(gameObject);
        }
    }
}
