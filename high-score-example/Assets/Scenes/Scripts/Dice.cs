using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    
    public void RollDice()
    {
        int randomNumber = Random.Range(0, 101);
        scoreText.text = "SCORE : " + randomNumber.ToString();

        if (randomNumber > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", randomNumber);
            highScoreText.text = "HIGH SCORE : " + randomNumber.ToString();
        }
    }

    public void ResetHighScore()
    {
        // PlayerPrefs.DeleteAll();
        PlayerPrefs.DeleteKey("HighScore");
        highScoreText.text = "HIGH SCORE : 0";
    }

    private void Start()
    {
        RestoreHighScore();
    }

    private void Update()
    {
        //
    }

    private void RestoreHighScore()
    {
        highScoreText.text = "HIGH SCORE : " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}
