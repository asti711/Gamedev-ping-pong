using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Text scoreText;

    public int firstPlayerScore = 0;
    public int secondPlayerScore = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateText()
    {
        scoreText.text = firstPlayerScore + " : " + secondPlayerScore;
    }

    public void managePlayerScore(int nScoredPlayer)
    {
        if (nScoredPlayer == 1)
        {
            firstPlayerScore++;
        }
        else
        {
            secondPlayerScore++;
        }

        updateText();
    }
}
