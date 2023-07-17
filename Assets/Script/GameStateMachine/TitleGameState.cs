using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleGameState : MonoBehaviour
{
    public void ChangeToMainMenu()
    {
        if (GameStateMachine.instance != null)
        {
           GameStateMachine.instance.MainMenu(gameObject);
        }
    }
}
