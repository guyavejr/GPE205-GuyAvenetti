using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameStateMachine gameStateMachine;
    //prefabs
    public GameObject PlayerControllerPrefab;
    public GameObject tankPawnPrefab;
    public Transform playerSpawnTransform;
    //list that holds players
    public List<PlayerController> players;
    
    public float lives;
    public int points;
    

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
    }

    public void RestartLevel()
    {
        Destroy(gameObject);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        
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
        
        Debug.Log(points);
    }

    public void LoseLife()
    {
        Debug.Log("loselifeGM");
        if (lives >= 1)
        {
            lives = lives - 1;
        }
        if (lives == 0)
        {
            gameStateMachine.GameOver(gameObject);
        }
    }

}
