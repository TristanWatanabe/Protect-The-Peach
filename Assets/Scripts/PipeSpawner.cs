﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour {

    //max Y position a pipe can be spawned
    public float maxYpos;
    //how much time interval will we spawn our pipes
    public float spawnTime;
    public GameObject pipe;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StopSpawningPipes()
    {
        CancelInvoke("SpawnPipe");
    }

    public void StartSpawningPipes()
    {

        InvokeRepeating("SpawnPipe", 0.2f, spawnTime);
    }

    void SpawnPipe()
    {
        //pipe GameObject is instatiated in the same X position, Y position is Randmoized, Z position is zero, Quaternion identity means there will be no rotation
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(-maxYpos, maxYpos), 0), Quaternion.identity);

    }

}
