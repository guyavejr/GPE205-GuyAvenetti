using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public void OptionsButton()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.gameStateMachine.Options(gameObject);
        }
    }
}
