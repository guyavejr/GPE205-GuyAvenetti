using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //prefabs
    public GameObject PlayerControllerPrefab;
    public GameObject tankPawnPrefab;

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
       // SpawnPlayer();
    }
    //spawn player controller 
    //GameObject newPlayerObj = Instantiate(PlayerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

    public Transform playerSpawnTransform;
    //spawn pawn and connect 
    //GameObject newPawnObj = Instantiate(tankPawnPrefab, playerSpawnTransform.position, playerSpawnTransform.rotation) as GameObject;
    

    
}
