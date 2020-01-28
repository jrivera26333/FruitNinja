using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Score Elements")]
    public int score;
    public Text scoreText;
    public Text highScoreText;
    public int highScore;

    [Header("Game Over")]
    public GameObject gameOverPanel;
    public Text gameOverPanelScoreText;
    public Text gameOverPanelHighScoreText;

    public void Awake()
    {
        gameOverPanel.SetActive(false);
        GetHighScore();
     
    }

    private void GetHighScore()
    {
        highScore = PlayerPrefs.GetInt("Highscore"); //PlayerPrefs saves small values
        highScoreText.text = "Best: " + highScore.ToString();
    }

    public void IncreaseScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();

        if(score > highScore)
        {
            PlayerPrefs.SetInt("Highscore", score); //We are storing the value score in that key
            highScoreText.text = score.ToString();
        }
    }

    public void OnBombHit()
    {
        Time.timeScale = 0; //Stop the game

        gameOverPanel.SetActive(true);
        gameOverPanelScoreText.text = "Score: " + score.ToString();
        gameOverPanelHighScoreText.text = "Best: " + highScore.ToString();
        Debug.Log("Bomb was hit!");
    }

    public void RestartGame()
    {
        score = 0;
        gameOverPanel.SetActive(false);
        scoreText.text = score.ToString();

        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            Destroy(g);
        }

        Time.timeScale = 1;
    }
    
}
