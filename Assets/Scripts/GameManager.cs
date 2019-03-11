using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    bool gameOver;

    private void Awake()
    {
        //this gameObject never gets destroyed when we go to a new scene,
        //problem is that if we reload the scene, it will create more and more GameManager objects
        DontDestroyOnLoad(this.gameObject);

        if(instance == null)
        {
            instance = this;
        }
        //fixes reload scene problem, when GameManager is RELOADED and an instance already exists, destroy that instance
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        gameOver = true;
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameStart()
    {
        
        UiManager.instance.GameStart();
        GameObject.Find("PipeSpawner").GetComponent<PipeSpawner>().StartSpawningPipes();
        //startbackground scroll
        BackgroundScroller.instance.StartScroll(1.5f);
        FindObjectOfType<AudioManager>().Play("InGameSound");
       
    }

    public void GameOver()
    {
        gameOver = false;
        GameObject.Find("PipeSpawner").GetComponent<PipeSpawner>().StopSpawningPipes();
        ScoreManager.instance.StopScore();
        UiManager.instance.GameOver();
        //stop background scroll
        BackgroundScroller.instance.StopScroll();
        FindObjectOfType<AudioManager>().Stop("InGameSound");
        AdManager.instance.showBanner();

    }
}
