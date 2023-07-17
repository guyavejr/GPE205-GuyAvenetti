using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpauseAndReturn : MonoBehaviour
{
    public void UnPauseReturnToGame()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.menuStateMachine.DeactivateAllStates();
        }
    }
}
