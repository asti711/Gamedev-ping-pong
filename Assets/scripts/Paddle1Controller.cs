using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle1Controller : MonoBehaviour {

    public Rigidbody paddleRigibody;
    public Transform paddleTransform;

    public Transform ballTransform;

    public float force = 5.0f;
    

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
        CheckInput();
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
