using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public void OptionsButton()
    {
        if (GameStateMachine.instance != null)
        {
            GameStateMachine.instance.Options(gameObject);
        }
    }
}
