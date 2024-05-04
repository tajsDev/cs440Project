using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreDisplay : MonoBehaviour
{
    Text txt;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
        if (ScoreTracker.currentScore > ScoreTracker.highScore)
        {
            ScoreTracker.highScore = ScoreTracker.currentScore;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        txt.text = "High score:" + ScoreTracker.highScore + "\n" + "Score:" + ScoreTracker.currentScore+"\n";
    }
}
