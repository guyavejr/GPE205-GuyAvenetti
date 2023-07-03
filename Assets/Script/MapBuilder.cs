using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MapBuilder : MonoBehaviour
{
    public GameObject[] gridPrefab;
    
    public int rows;
    public int cols;
    public float roomWidth = 50.0f;
    public float roomHeight = 50.0f;
    private Room[,] grid;

    public int mapSeed;
    public void Start()
    {
        GenerateMap();
    }
    public GameObject RandomRoomPrefab()
    {
        return gridPrefab[UnityEngine.Random.Range(0, gridPrefab.Length)];
    }
    public void GeneratePickupSpawnPrefab()
    {

    }

    public Boolean randomMap;
    public int DateToInt(DateTime dateToUse)
    {
        return dateToUse.Year + dateToUse.Month + dateToUse.Day + dateToUse.Hour + dateToUse.Minute + dateToUse.Second + dateToUse.Millisecond;
        UnityEngine.Random.seed = DateToInt(DateTime.Now);
    }
    public void GenerateMap()
    {
        if (randomMap == true)
        {
            grid = new Room[cols, rows];
            for (int currentRow = 0; currentRow < rows; currentRow++)
            {
                for (int currentCol = 0; currentCol < cols; currentCol++)
                {
                    float xPosition = roomWidth * currentCol;
                    float zPosition = roomHeight * currentRow;
                    Vector3 newPosition = new Vector3(xPosition, 0.0f, zPosition);

                    GameObject tempRoomObj = Instantiate(RandomRoomPrefab(), newPosition, Quaternion.identity) as GameObject;

                    tempRoomObj.transform.parent = this.transform;

                    tempRoomObj.name = "Room_" + currentCol + "," + currentRow;

                    Room tempRoom = tempRoomObj.GetComponent<Room>();

                    grid[currentCol, currentRow] = tempRoom;

                    //North South
                    if (currentRow == 0)
                    {
                        tempRoom.doorNorth.SetActive(false);
                    }
                    else if (currentRow == -1)
                    {
                        Destroy(tempRoom.doorSouth);
                    }
                    else if (currentRow == rows - 1)
                    {
                        tempRoom.doorNorth.SetActive(true);
                        tempRoom.doorSouth.SetActive(false);
                    }
                    else
                    {
                        Destroy(tempRoom.doorSouth);
                        Destroy(tempRoom.doorNorth);
                    }




                    //East West
                    if (currentCol == 0)
                    {
                        tempRoom.doorEast.SetActive(false);
                    }
                    else if (currentCol == -1)
                    {
                        Destroy(tempRoom.doorEast);
                    }
                    else if (currentCol == rows - 1)
                    {
                        tempRoom.doorEast.SetActive(true);
                        tempRoom.doorWest.SetActive(false);
                    }
                    else
                    {
                        Destroy(tempRoom.doorWest);
                        Destroy(tempRoom.doorEast);
                    }
                }

            }
        }
        else
        {
            UnityEngine.Random.seed = mapSeed;
            grid = new Room[cols, rows];
            for (int currentRow = 0; currentRow < rows; currentRow++)
            {
                for (int currentCol = 0; currentCol < cols; currentCol++)
                {
                    float xPosition = roomWidth * currentCol;
                    float zPosition = roomHeight * currentRow;
                    Vector3 newPosition = new Vector3(xPosition, 0.0f, zPosition);

                    GameObject tempRoomObj = Instantiate(RandomRoomPrefab(), newPosition, Quaternion.identity) as GameObject;

                    tempRoomObj.transform.parent = this.transform;

                    tempRoomObj.name = "Room_" + currentCol + "," + currentRow;

                    Room tempRoom = tempRoomObj.GetComponent<Room>();

                    grid[currentCol, currentRow] = tempRoom;

                    //North South
                    if (currentRow == 0)
                    {
                        tempRoom.doorNorth.SetActive(false);
                    }
                    else if (currentRow == -1)
                    {
                        Destroy(tempRoom.doorSouth);
                    }
                    else if (currentRow == rows - 1)
                    {
                        tempRoom.doorNorth.SetActive(true);
                        tempRoom.doorSouth.SetActive(false);
                    }
                    else
                    {
                        Destroy(tempRoom.doorSouth);
                        Destroy(tempRoom.doorNorth);
                    }




                    //East West
                    if (currentCol == 0)
                    {
                        tempRoom.doorEast.SetActive(false);
                    }
                    else if (currentCol == -1)
                    {
                        Destroy(tempRoom.doorEast);
                    }
                    else if (currentCol == rows - 1)
                    {
                        tempRoom.doorEast.SetActive(true);
                        tempRoom.doorWest.SetActive(false);
                    }
                    else
                    {
                        Destroy(tempRoom.doorWest);
                        Destroy(tempRoom.doorEast);
                    }
                }

            }
        }
    }
}
