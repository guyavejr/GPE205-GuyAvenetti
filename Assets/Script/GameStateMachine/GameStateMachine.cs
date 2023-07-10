using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateMachine : MonoBehaviour
{   public GameStates currentGameState;

    //GameStates
    public GameObject TitleScreenStateObject;
    public GameObject MainMenuStateObject;
    public GameObject OptionsScreenStateObject;
    public GameObject CreditsScreenStateObject;
    public GameObject GamePlayStateObject;
    public GameObject GameOverScreenStateObject;
    public enum GameStates
    {
        TitleScreen, MainMenu, Options, GamePlay, GameOver, Credits
    }
    private void Start()
    {
        TitleScreen(gameObject);
    }
    private void Update()
    {
        
    }

    public virtual void ChangeGameState(GameStates newGameState)
    {
        // change the current state 
        currentGameState = newGameState;
    }
    public virtual void TitleScreen(GameObject gameObject)
    {
        ActivateTitleScreen();
    }
    public virtual void MainMenu(GameObject gameObject)
    {
        ActivateMainMenu();
    }
    public virtual void Options(GameObject gameObject)
    {
            ActivateOptionsScreen(); 
    }
    public virtual void GamePlay(GameObject gameObject)
    {
        ActivateGamePlay();
    }
    public virtual void GameOver(GameObject gameObject)
    {
        ActivateGameOverScreen();  
    }
    public virtual void Credits(GameObject gameObject)
    {
        ActivateCreditsScreen();
    }
    private void DeactivateAllStates()
    {
        TitleScreenStateObject.SetActive(false);
        MainMenuStateObject.SetActive(false);
        OptionsScreenStateObject.SetActive(false);
        CreditsScreenStateObject.SetActive(false);
        GamePlayStateObject.SetActive(false);
        GameOverScreenStateObject.SetActive(false);
    }
    public void ActivateTitleScreen()
    {
        DeactivateAllStates();
        TitleScreenStateObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ActivateMainMenu()
    {
        DeactivateAllStates();
        MainMenuStateObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ActivateOptionsScreen()
    {
        DeactivateAllStates();
        OptionsScreenStateObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ActivateCreditsScreen()
    {
        DeactivateAllStates();
        CreditsScreenStateObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ActivateGamePlay()
    {
        DeactivateAllStates();
        GamePlayStateObject.SetActive(true);
        Time.timeScale = 1f;
    }
    public void ActivateGameOverScreen()
    {
        DeactivateAllStates();
        GameOverScreenStateObject.SetActive(true);
        Time.timeScale = 0f;
    }
}

