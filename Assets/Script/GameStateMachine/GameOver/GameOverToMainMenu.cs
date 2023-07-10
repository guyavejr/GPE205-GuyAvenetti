using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverToMainMenu : MonoBehaviour
{
    public void ChangeToMainMenuFromGameOver()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.gameStateMachine.MainMenu(gameObject);
        }
    }
}
