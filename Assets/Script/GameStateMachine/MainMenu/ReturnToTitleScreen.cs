using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToTitleScreen : MonoBehaviour
{
    public void ReturnToTitleScreenButton()
    {
        if (GameStateMachine.instance != null)
        {
            GameStateMachine.instance.TitleScreen(gameObject);
        }
    }
}
