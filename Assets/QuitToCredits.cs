using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitToCredits : MonoBehaviour
{
     public void OpenCredits()
    {
        GameManager.instance.menuStateMachine.ActivateCreiditsScreen(gameObject);
    }
}
