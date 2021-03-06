﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle2Controller : MonoBehaviour {

    public Rigidbody paddleRigibody;
    public Transform paddleTransform;

    public Transform ballTransform;

    public float force = 5.0f;
    public bool playerControl;

    // Use this for initialization
    void Start()
    {
        ballTransform = GameObject.FindGameObjectWithTag("Ball").GetComponent<Transform>();
        paddleTransform = this.gameObject.GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (playerControl)
        {
            CheckInput();
        }
        else
        {
            ComputerControl();
        }

    }

    public void ComputerControl()
    {
        if (ballTransform.position.y > paddleTransform.position.y)
        {
            moveUp();
        }
        if (ballTransform.position.y < paddleTransform.position.y)
        {
            moveDown();
        }
    }

    public void CheckInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveUp();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
           moveDown();
        }
        
        
    }

    public void moveUp()
    {
        paddleRigibody.AddForce(Vector3.up * force);
    }

    public void moveDown()
    {
        paddleRigibody.AddForce(Vector3.down * force);
    }

}
