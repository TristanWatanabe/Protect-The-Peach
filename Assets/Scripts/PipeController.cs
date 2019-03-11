using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour {

    //speed of pipe
    public float speed;
    public float upDownSpeed;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        MovePipe();
        //after 1 second, change direction from up to down and vice versa
        InvokeRepeating("SwitchUpDown", 0.1f, 2f);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //changes upDownSpeed automatically, moves up or down
    void SwitchUpDown()
    {
        upDownSpeed = -upDownSpeed;
        rb.velocity = new Vector2(speed, upDownSpeed);
    }

    void MovePipe()
    {

        rb.velocity = new Vector2(-speed, upDownSpeed);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "PipeRemover")
        {
            Destroy(gameObject);
        }    
    }
}
