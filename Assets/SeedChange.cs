using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SeedChange : MonoBehaviour
{
    public MapBuilder mapBuilder;

    public TMP_InputField inputField;

    public int newSeed;

    public void ConvertToInt()
    {
        string inputString = inputField.text;
        int convertedValue;

        if (int.TryParse(inputString, out convertedValue))
        {
            Debug.Log("converted value:" + convertedValue);

            newSeed = convertedValue;
        }
        else
        {
            Debug.Log("convert failed");
        }
    }

    public void SetNewSeed()
    {
        if (mapBuilder != null)
        {
            mapBuilder.mapSeed = newSeed;
        }
        if (mapBuilder.mapSeed == 0)
        {
            mapBuilder.randomMap = true;
        }
        if (mapBuilder.mapSeed > 0)
        {
            mapBuilder.randomMap = false;
        }

    }

}
