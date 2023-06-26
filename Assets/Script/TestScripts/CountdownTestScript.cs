using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTestScript : MonoBehaviour
{

    public float shootDelay = 1.0f;
    private float nextEventTime;

    // Start is called before the first frame update
    void Start()
    {
        nextEventTime = shootDelay;
    }

    // Update is called once per frame
    void Update()
    {
        nextEventTime -= Time.deltaTime;
        if (nextEventTime <= 0)
        {
            Debug.Log("Timer");
            nextEventTime = shootDelay;
        }
    }
}
