using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    public static BackgroundScroller instance;
    //speed of scroll
    public float speed;
    //starting position
    Vector3 startPOS;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    // Use this for initialization
    void Start()
    {
        speed = 0;
    }

    public void StartScroll(float scrollSpeed)
    {
        startPOS = transform.position;
        speed = scrollSpeed;
        
    }

    public void StopScroll()
    {
        speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((new Vector3(-1, 0, 0)) * speed * Time.deltaTime);

        if (transform.position.x < -17.61011)
        {
            transform.position = startPOS;
        }
    }
}
