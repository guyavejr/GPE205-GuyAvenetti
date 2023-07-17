using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColumnChange : MonoBehaviour
{
    public MapBuilder mapBuilder;

    public TMP_InputField inputField;

    public int newColumn;

    public void ConvertToInt()
    {
        string inputString = inputField.text;
        int convertedValue;

        if (int.TryParse(inputString, out convertedValue))
        {
            Debug.Log("converted value:" + convertedValue);

            newColumn = convertedValue;
        }
        else
        {
            Debug.Log("convert failed");
        }
    }

    public void SetNewColumn()
    {
        if (mapBuilder != null)
        {
            mapBuilder.cols = newColumn;
        }
        if (mapBuilder.cols == 0)
        {
            mapBuilder.cols = 3;
        }
    }

}
