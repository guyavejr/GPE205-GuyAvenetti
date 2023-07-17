using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public MenuStateMachine menuStateMachine;
    
    
    //prefabs
    public GameObject PlayerControllerPrefab;
    public GameObject tankPawnPrefab;
    public GameObject mapGenerator;
    public Transform playerSpawnTransform;
    //list that holds players
    public List<PlayerController> players;
    
    public float lives;
    public int points;

    public string targetSceneName = "World1";
    //awake runs before start
    private void Awake()
    {
        //if the instance doesnt exist
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //start
    private void Start()
    {
        SpawnPlayer();
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == targetSceneName)
        {
            Instantiate(mapGenerator);
            MapBuilder.instance.GenerateMap();
        }
        else
        {
            return;
        }
        

    }

    public void ContinueToTheBossWorld()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("World2");
    }
    public void RestartLevelWorld1()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("World1");
        
    }

    public void ExitToMainMenuFromWorld1()
    {
        MapBuilder.instance.DestroyMap();
        SceneManager.LoadSceneAsync("Main");
        Destroy(gameObject);
    }

    public void MultiPlayer()
    {
        Destroy(gameObject);
        SceneManager.LoadSceneAsync("MultiPlayerTest");
    }
    public void SpawnPlayer()
    {
        //spawn player controller 
        GameObject newPlayerObj = Instantiate(PlayerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        PlayerController newController = newPlayerObj.GetComponent<PlayerController>();

        //spawn pawn and connect 
        GameObject newPawnObj = Instantiate(tankPawnPrefab, playerSpawnTransform.position, playerSpawnTransform.rotation) as GameObject;

        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        newController.pawn = newPawn;
    }

    public void AddPoint()
    {
        points = points + 1;
        
        if (points >= MapBuilder.instance.rows * MapBuilder.instance.cols + 3)
        {
            menuStateMachine.ActivateWinScreen(gameObject);
        }
    }

    public void LoseLife()
    {
        if (lives >= 1)
        {
            lives = lives - 1;
        }
        if (lives == 0)
        {
            menuStateMachine.ActivateLoseScreen(gameObject);
        }
    }

}
