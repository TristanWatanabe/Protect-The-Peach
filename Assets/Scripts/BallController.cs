using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    Rigidbody2D rb;
    public float upForce;
    public float rotation;
    //tells game if it started or not
    bool started;
    bool gameOver;

	// Use this for initialization
	void Start () {
        //gives us access to the RigidBody of this object
        rb = GetComponent<Rigidbody2D>();
        started = false;
        gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!started)
        {
            //mouse button is clicked for first time so start the game
            if (Input.GetMouseButtonDown (0))
            {
                started = true;
                rb.isKinematic = false;
                GameManager.instance.GameStart();
                

            }
        }
        else if (started && !gameOver)
        {
            //rotates ball
            transform.Rotate(0, 0, rotation);
            //if game already started, add upForce to the ball
            if(Input.GetMouseButtonDown(0))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0, upForce));

                FindObjectOfType<AudioManager>().Play("JumpSound");


            }
        }
	}

    //if ball collides with anything = game over
    void OnCollisionEnter2D(Collision2D col)
    {
        gameOver = true;
        //makes collision sound when ball hits ground
        FindObjectOfType<AudioManager>().Play("CollideSound");
        GameManager.instance.GameOver();
        GetComponent<Animator>().Play("peach");

        //unchecks isTrigger for the pipeholder pipes so ball actually collides with those objects
        GameObject.Find("toppipe").GetComponent<BoxCollider2D>().isTrigger = false;
        GameObject.Find("bottompipe").GetComponent<BoxCollider2D>().isTrigger = false;
    }

    //if ball collides with a Pipe
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Pipe" && !gameOver)
        {
            gameOver = true;
            //makes moan sound when ball hits pipe
            FindObjectOfType<AudioManager>().Play("MoanSound");
            GameManager.instance.GameOver();

            GetComponent<Animator>().Play("peach");

            GameObject.Find("toppipe").GetComponent<BoxCollider2D>().isTrigger = false;
            GameObject.Find("bottompipe").GetComponent<BoxCollider2D>().isTrigger = false;

           
        }

        //if ball object collides with trigger with tag "Score Checker", increase score
        if (col.gameObject.tag == "ScoreChecker" && !gameOver)
        {
            FindObjectOfType<AudioManager>().Play("ScoreSound");

            ScoreManager.instance.IncrementScore();
        }    
    }
}
