using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public BallController ballController;

    public Text scoreText;
    public Text winnerText;
    public GameObject endGamePanel;

    public int firstPlayerScore = 0;
    public int secondPlayerScore = 0;
    public int winScore = 11;
    public bool wonGame = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateScoreText()
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

        updateScoreText();

        CheckIfOneWon();
    }

    public void CheckIfOneWon()
    {
        if(firstPlayerScore >= winScore)
        {
            wonGame = true;
            ManageEndGame(1);
        }
        else if(secondPlayerScore >= winScore)
        {
            wonGame = true;
            ManageEndGame(2);
        }
    }

    public void ManageEndGame(int numPlayerWinner)
    {
        endGamePanel.SetActive(true);

        ShowWinner(numPlayerWinner);
    }

    public void ShowWinner(int numPlayerWinner)
    {
        string winMessage = "Player " + numPlayerWinner + " wins the game!";

        winnerText.text = winMessage;
    }

    public void Restart()
    {
        firstPlayerScore = 0;
        secondPlayerScore = 0;
        wonGame = false;
        updateScoreText();

        winnerText.text = "";
        winnerText.enabled = false;

        endGamePanel.SetActive(false);

        ballController.ManageBallMove(0);

    }

}
