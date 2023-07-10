using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsToMainMenu : MonoBehaviour
{
    public void ChangeToMainMenuFromOptions()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.gameStateMachine.MainMenu(gameObject);
        }
    }
}
