using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPlayer : MonoBehaviour
{
    public void MultiPlayerButtonButton()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.MultiPlayer();
        }
    }
}
