using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStateMachine : MonoBehaviour
{   public GameStates currentGameState;
    public static GameStateMachine instance;
    //GameStates
    public GameObject TitleScreenStateObject;
    public GameObject MainMenuStateObject;
    public GameObject OptionsScreenStateObject;
    public GameObject CreditsScreenStateObject;
    public GameObject GamePlayStateObject;
    public GameObject TutorialObject;
    public enum GameStates
    {
        TitleScreen, MainMenu, Options, GamePlay, Tutorial, Credits
    }
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        ChooseGameState();
    }
    private void Update()
    {
        
    }
    public virtual void ChooseGameState()
    {
        switch (currentGameState)
        {
            case GameStates.TitleScreen:
                TitleScreen(gameObject);
                break;
            case GameStates.MainMenu:
                MainMenu(gameObject);
                break;

        }
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
    public virtual void Tutorial(GameObject gameObject)
    {
        
        ActivateTutorialScreen();
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
        TutorialObject.SetActive(false);
    }
    public void ActivateTitleScreen()
    {
        DeactivateAllStates();
        TitleScreenStateObject.SetActive(true);
        
    }
    public void ActivateMainMenu()
    {
        DeactivateAllStates();
        MainMenuStateObject.SetActive(true);
        
    }
    public void ActivateOptionsScreen()
    {
        DeactivateAllStates();
        OptionsScreenStateObject.SetActive(true);
        
    }
    public void ActivateCreditsScreen()
    {
        DeactivateAllStates();
        CreditsScreenStateObject.SetActive(true);
        
    }
    public void ActivateGamePlay()
    {
        SceneManager.LoadSceneAsync("World1");
    }
    public void ActivateTutorialScreen()
    {
        
        TutorialObject.SetActive(true);
        
    }
}

