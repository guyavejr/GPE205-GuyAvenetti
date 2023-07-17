using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToMainMenu : MonoBehaviour
{
    
    public void ExitToMainMenu()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ExitToMainMenuFromWorld1();
        }
    }
}
