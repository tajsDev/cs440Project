using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
public class ScoreTracker : MonoBehaviour
{
    public static int highScore = 0 ;
    public static int currentScore = 0 ;
    public static Stopwatch time = new Stopwatch();
    public static bool isEndless = false;
    // Start is called before the first frame update
    void Awake()
    {
        setNewScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void setNewScore() {
        if(currentScore > highScore) highScore = currentScore;
        currentScore = 0 ;
    }
}
