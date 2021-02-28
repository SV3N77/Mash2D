using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private static int scoreValue = 0;
    Text Score;
    
    // Start is called before the first frame update
    void Start()
    {
        Score = GetComponent<Text>();
    }
    // Update is called once per frame
    public static void AddScore(int newScoreValue)
    {
        scoreValue =+ newScoreValue;
    }
    
    void Update()
    {
        Score.text = "Soldier's Rescued: " + scoreValue;
    }
}
