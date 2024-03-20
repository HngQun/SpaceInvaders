using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;

public class GameManeger : MonoBehaviour
{
    public int playerScore = 0;
    public TextMeshProUGUI scoreText;

    public GameObject gameOverOj;

    public void addScore()
    {
        playerScore += 1;
        scoreText.text = playerScore.ToString();
    }

    public void playAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if(playerScore == 16){
            gameOverOj.SetActive(true);

        }
        else{
            gameOverOj.SetActive(false);
        }
    }

}
