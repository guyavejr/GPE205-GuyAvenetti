using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleGameState : MonoBehaviour
{
    public void ChangeToMainMenu()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.gameStateMachine.MainMenu(gameObject);
        }
    }
}
