/*
* GRoup 1
* Project 4
* repeatrs the backgorund
*/﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition; 

    // Start is called before the first frame updateprivate Vector3 startPosition; 
    private float repeatWidith; 
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position; 

        repeatWidith = GetComponent<BoxCollider>().size.x / 2; 
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPosition.x - repeatWidith)
        {
            transform.position = startPosition; 
        }
    }
}
