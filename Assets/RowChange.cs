using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RowChange : MonoBehaviour
{
    public MapBuilder mapBuilder;

    public TMP_InputField inputField;

    public int newRow;

    public void ConvertToInt()
    {
        string inputString = inputField.text;
        int convertedValue;

        if (int.TryParse(inputString, out convertedValue))
        {
            newRow = convertedValue;
        }
    }

    public void SetNewRow()
    {
        if (mapBuilder != null)
        {
            mapBuilder.rows = newRow;
        }
        if (mapBuilder.rows == 0)
        {
            mapBuilder.rows = 3;
        }
    }

}
