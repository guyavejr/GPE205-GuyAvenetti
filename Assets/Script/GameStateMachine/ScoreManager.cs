using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    
    public Text scoreText;
    public int points;
    public void Start()
    {
        
    }
    public void Update()
    {
        points = GameManager.instance.points;
        scoreText.text = points.ToString() + " tanks destroyed";
    }

    public void AddPoint()
    {
        points = GameManager.instance.points;
        scoreText.text = points.ToString() + " tanks destroyed";
    }
}
