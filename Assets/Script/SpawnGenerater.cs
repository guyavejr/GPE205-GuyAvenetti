using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SpawnGenerator : MonoBehaviour
{
    public GameObject[] spawnerPickupPrefab;
    public void Start()
    {
        CreateSpawn();
    }
    public GameObject RandomPickupPrefab()
    {
        return spawnerPickupPrefab[UnityEngine.Random.Range(0, spawnerPickupPrefab.Length)];
    }

    public void CreateSpawn()
    {
         Vector3 randomPos = new Vector3(UnityEngine.Random.Range(-22f, 120f), UnityEngine.Random.Range(1f, 1f), UnityEngine.Random.Range(-25f, 120f));
         GameObject tempPickupObj = Instantiate(RandomPickupPrefab(), randomPos, Quaternion.identity) as GameObject;

         tempPickupObj.transform.parent = this.transform;

         PickupSpawner tempPickup = tempPickupObj.GetComponent<PickupSpawner>();
    }
}
 