using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTutorial : MonoBehaviour
{
    public void ActivateTutorial()
    {
        GameStateMachine.instance.Tutorial(gameObject);
    }
}
