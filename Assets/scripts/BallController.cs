using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public GameController gameController;
    public Rigidbody ballRigidBody;
    public Transform ballTransform; //determine position
    public bool isPlaying = false;

	// Use this for initialization
	void Start () {
        ballTransform = this.transform;
        BallMove();
	}

    // Update is called once per frame
    void Update() {
        if (isPlaying)
        {
            CheckInBoundaries();
        }
        
	}

    public void BallMove()
    {
        ballRigidBody.AddForce(new Vector3(1, 0), ForceMode.Impulse);
        isPlaying = true;
    }

    public void CheckInBoundaries()
    {
        if (ballTransform.position.x < -9.3 || ballTransform.position.x > 9.3)
        {
            int nScoredPlayer = 0;
            isPlaying = false;

            if(ballTransform.position.x < 0)
            {
                nScoredPlayer = 2;
            }
            else
            {
                nScoredPlayer = 1;
            }

            gameController.managePlayerScore(nScoredPlayer);
            //остановить и поставить снова на позицию
            ResetBall();
        }
    }

    public void BallDirection()
    {

    }

    public void ResetBall()
    {
        ballRigidBody.velocity = Vector3.zero;
        ballTransform.position = Vector3.zero;

        BallMove();
    }
}