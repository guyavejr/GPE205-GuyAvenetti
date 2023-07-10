using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToTitleScreen : MonoBehaviour
{
    public void ReturnToTitleScreenButton()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.gameStateMachine.TitleScreen(gameObject);
        }
    }
}
