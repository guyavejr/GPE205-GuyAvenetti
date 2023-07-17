using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStateMachine : MonoBehaviour
{
    

    public GameObject WinScreen;
    public GameObject LoseScreen;
    public GameObject OptionsScreen;
    public GameObject CreditsScreen;

    public Menu currentMenu;

    public bool IsPaused;

    public virtual void SetIsPaused()
    {
        if (IsPaused == true)
        {
            Time.timeScale = 0f;
        }
        else Time.timeScale = 1f;
    }
    public enum Menu
    {
        WinScreen, LooseScreen, OptionsScreen, CreditsScreen
    }

    private void Start()
    {
        DeactivateAllStates();
        SetIsPaused();
    }

    public virtual void ActivateLoseScreen(GameObject gameObject)
    {
        LoseScreen.SetActive(true);
        IsPaused = true;
        SetIsPaused();

    }
    public virtual void ActivateWinScreen(GameObject gameObject)
    {
        WinScreen.SetActive(true);
        IsPaused = true;
        SetIsPaused();

    }
    public virtual void ActivateOptionsScreen(GameObject gameObject)
    {
        OptionsScreen.SetActive(true);
        IsPaused = true;
        SetIsPaused();

    }
    public virtual void ActivateCreiditsScreen(GameObject gameObject)
    {
        CreditsScreen.SetActive(true);
        IsPaused = true;
        SetIsPaused();

    }
    public void DeactivateAllStates()
    {
        IsPaused = false;
        WinScreen.SetActive(false);
        LoseScreen.SetActive(false);
        OptionsScreen.SetActive(false);
        CreditsScreen.SetActive(false);
        SetIsPaused();
    }


}
