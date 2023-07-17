using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public void CreditsButton()
    {
        if (GameStateMachine.instance != null)
        {
           GameStateMachine.instance.Credits(gameObject);
        }
    }
}
