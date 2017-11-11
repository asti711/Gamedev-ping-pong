using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

    public Rigidbody paddleRigibody;
    public Transform paddleTransform;

    public Transform ballTransform;


    public float force = 5.0f;
    public int no;
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
        Vector3 pos = paddleTransform.position;
        pos.z = 0;
        paddleTransform.position = pos;
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
        if (Input.GetKey(KeyCode.W))
        {
            moveUp();
        }

        if (Input.GetKey(KeyCode.S))
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
