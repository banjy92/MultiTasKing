using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour {
    private static int score;
    private float realScore;

    public TextMeshProUGUI scoreboard;
    

    public static int Score
    {
        get
        {
            return score;
        }
    }

    // Use this for initialization
    void Start () {
        score = 0;
        realScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
        realScore += Time.deltaTime;
        score = (int)realScore;
        UpdateScore();
	}

    public void UpdateScore()
    {
        scoreboard.text = score.ToString();
    }
}
