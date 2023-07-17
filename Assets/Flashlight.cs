using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject flashlightToToggle;
    [SerializeField] GameObject laserPointerToggle;
    public bool flashlightActive = false;
    public bool laserPointerActive = false;
    private void Start()
    {
        flashlightToToggle.gameObject.SetActive(false);
        laserPointerToggle.gameObject.SetActive(false);
    }
    public void ToggleFlashlight()
    {

        if (flashlightActive == true)
        {
            flashlightToToggle.gameObject.SetActive(false);
            flashlightActive = false;
            laserPointerToggle.gameObject.SetActive(true);
            laserPointerActive = true;
        }
        else
        {
            laserPointerToggle.gameObject.SetActive(false);
            laserPointerActive = false;
            flashlightToToggle.gameObject.SetActive(true);
            flashlightActive = true;
        }
    }
}


