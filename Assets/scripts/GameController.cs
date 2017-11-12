using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Text scoreText;
    public Text winnerText;

    public int firstPlayerScore = 0;
    public int secondPlayerScore = 0;
    public int winScore = 11;

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

    public void ManagePlayerScore(int numScoredPlayer)
    {
        if (numScoredPlayer == 1)
        {
            firstPlayerScore++;
        }
        else
        {
            secondPlayerScore++;
        }

        updateText();

        CheckIfOneWon();
    }

    public void CheckIfOneWon()
    {
        if(firstPlayerScore >= winScore)
        {
            ManageEndGame(1);
        }
        else if(secondPlayerScore >= winScore)
        {
            ManageEndGame(2);
        }
    }

    public void ManageEndGame(int numPlayerWinner)
    {
        ShowWinner(numPlayerWinner);
    }

    public void ShowWinner(int numPlayerWinner)
    {
        string winMessage = "Player " + numPlayerWinner + " wins the game!";

        winnerText.text = winMessage;
    }
}
