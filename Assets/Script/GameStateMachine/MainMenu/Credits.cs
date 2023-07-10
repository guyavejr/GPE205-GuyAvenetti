using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public void CreditsButton()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.gameStateMachine.Credits(gameObject);
        }
    }
}
