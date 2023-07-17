using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsToMainMenu : MonoBehaviour
{
    public void ChangeToMainMenuFromOptions()
    {
        if (GameStateMachine.instance != null)
        {
            GameStateMachine.instance.MainMenu(gameObject);
        }
    }
}
