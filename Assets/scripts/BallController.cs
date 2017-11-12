using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public GameController gameController;
    public Rigidbody ballRigidBody;
    public Transform ballTransform; //determine position
    public bool isPlaying = false;
    public Vector3 dirV;

	// Use this for initialization
	void Start () {
        ballTransform = this.transform;
        BallDirection(0);
	}

    // Update is called once per frame
    void Update() {
        if (isPlaying)
        {
            CheckInBoundaries();
        }
        
	}

    public void BallDirection(int scoredPlayer)
    {
        if (scoredPlayer == 1)
        {
            ManageBallMove(1);
        }
        else if (scoredPlayer == 2)
        {
            ManageBallMove(-1);
        }
        else
        {
            ManageBallMove(0);
        }

    }

    public void ManageBallMove(int dir)
    {
        float dirX = 0;
        if (dir == 0)
        {
            dirX = GetRandomDirection();
        }
        else
        {
            dirX = dir;
        }
        float angleY = GetRandomAngle();
        dirV = new Vector3(dirX, angleY);
        BallMove();
    }

    public float GetRandomAngle()
    {
        return UnityEngine.Random.Range(0.25f, 0.75f);
    }

    public int GetRandomDirection()
    {
        int randomDir = 0;
        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            randomDir = -1;
        }
        else
        {
            randomDir = 1;
        }
        return randomDir;
    }

    public void BallMove()
    {
        ballRigidBody.AddForce(dirV, ForceMode.Impulse);
        isPlaying = true;
    }

    public void CheckInBoundaries()
    {
        if (ballTransform.position.x < -9.3 || ballTransform.position.x > 9.3)
        {
            int nScoredPlayer = 0;
            isPlaying = false;

            if (ballTransform.position.x < 0)
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

            BallDirection(nScoredPlayer);
        }
    }

    

    public void ResetBall()
    {
        ballRigidBody.velocity = Vector3.zero;
        ballTransform.position = Vector3.zero;

        
    }
}