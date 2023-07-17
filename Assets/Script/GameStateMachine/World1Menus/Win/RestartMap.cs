using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartMap : MonoBehaviour
{
    public void RestartLevelAfterWinLose()
    {
        if (GameManager.instance != null)
        {

            GameManager.instance.RestartLevelWorld1();
        }
    }
}
