using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text highscoreText;
    public Text currentscoreText;
    public Text winner;
    public GameObject winnerUI;
    public GameObject highscoreUI;
    public GameObject currentscoreUI;
    public int highscore;
    public int currentscore;
    public string gameMode;
    // Start is called before the first frame update
    void Start()
    {
        gameMode = FindObjectOfType<BallMovement>().gameMode;

        if (gameMode != "versus")
		{
            if (gameMode == "solo")
            {
                highscore = PlayerPrefs.GetInt("Highscore solo");
                currentscore = PlayerPrefs.GetInt("Score solo");
            }
            else if (gameMode == "team")
            {
                highscore = PlayerPrefs.GetInt("Highscore team");
                currentscore = PlayerPrefs.GetInt("Score team");
            }
            highscoreText.text = "Highscore: " + highscore.ToString();
            currentscoreText.text = "Current Score: " + currentscore.ToString();
        }
        else
		{
            FindObjectOfType<AudioManager>().Play("Versus");
            highscoreUI.SetActive(false);
            currentscoreUI.SetActive(false);
            winner.text = "Winner: " + BallMovement.versusWin;
            winnerUI.SetActive(true);
		}
    }
}
