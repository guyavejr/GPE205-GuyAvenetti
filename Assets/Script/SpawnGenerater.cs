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

    public int DateToInt(DateTime dateToUse)
    {
        return dateToUse.Year + dateToUse.Month + dateToUse.Day + dateToUse.Hour + dateToUse.Minute + dateToUse.Second + dateToUse.Millisecond;
        UnityEngine.Random.seed = DateToInt(DateTime.Now);
    }
    public void CreateSpawn()
    {
         Vector3 randomPos = new Vector3(UnityEngine.Random.Range(-24f, 123f), UnityEngine.Random.Range(1f, 1f), UnityEngine.Random.Range(-24f, 123f));
         GameObject tempPickupObj = Instantiate(RandomPickupPrefab(), randomPos, Quaternion.identity) as GameObject;

         tempPickupObj.transform.parent = this.transform;

         PickupSpawner tempPickup = tempPickupObj.GetComponent<PickupSpawner>();
    }
}
 