/*
* GRoup 1
* Project 4
* responsible for the logic to make the background scroll
*/﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
     [SerializeField]
    private float scrollSpeed = 1f;

    private float rightEdge;
    private float leftEdge;
    private Vector3 distanceBetweenEdges;
    // Start is called before the first frame update
    private void Start()
    {
        CalculateEdges();

        distanceBetweenEdges = new Vector3(rightEdge - leftEdge, 0f, 0f);
    }

    private void CalculateEdges() {
        var sprRenderer = GetComponent<SpriteRenderer>();
        rightEdge = transform.position.x + sprRenderer.bounds.extents.x / 3f; 
        leftEdge = transform.position.x - sprRenderer.bounds.extents.x / 3f; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += scrollSpeed * Vector3.right * Time.deltaTime;

        if (PassedEdges()) {
            MoveRightSpriteToOppositeEdge();
        }
    }

    private bool PassedEdges() {
        return scrollSpeed > 0 && transform.position.x > rightEdge ||
            scrollSpeed < 0 && transform.position.x < leftEdge;
    }

    private void MoveRightSpriteToOppositeEdge() {
        if (scrollSpeed > 0) {
            transform.position -= distanceBetweenEdges;
        } else {
            transform.position += distanceBetweenEdges;
        }
    }
}
