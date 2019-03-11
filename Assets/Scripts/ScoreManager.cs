using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance;
    public int score;

    //creates ScoreManager instance
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start () {
        score = 0;
        PlayerPrefs.SetInt("Score", 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void IncrementScore()
    {
        score++;
    }

    public void StopScore()
    {
        PlayerPrefs.SetInt("Score", score);

        if (PlayerPrefs.HasKey("HighScore"))
        {   
            //checks if current score is greater than high score
            if(score > PlayerPrefs.GetInt("HighScore"))
            {   
                //if yes, set current score as new high score
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

    }
}
