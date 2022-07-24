using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{

    public float speed = 100f;
    public Rigidbody2D rb;
    public int score = 0;
    public Text scoreText;
    public int P1score = 0;
    public Text P1scoreText;
    public int P2score = 0;
    public Text P2scoreText;
    public GameObject gameOverUI;
    public string gameMode;
    public static string versusWin;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Score solo", 0);
        PlayerPrefs.SetInt("Score team", 0);
        PlayerPrefs.SetInt("P1 Score", 0);
        PlayerPrefs.SetInt("P2 Score", 0);
        StartCoroutine(AddStartingForce());
        gameMode = MenuHandler.gameMode;
        gameOver = false;
    }
    
	void FixedUpdate()
	{
		if(P1score == 10)
		{
            versusWin = "Player 1";
            rb.velocity = Vector2.zero;
            gameOver = true;
            gameOverUI.SetActive(true);
        }
        
        if(P2score == 10)
		{
            versusWin = "Player 2";
            rb.velocity = Vector2.zero;
            gameOver = true;
            gameOverUI.SetActive(true);
        }

        if (Mathf.Abs(rb.velocity.y) < 2f && rb.velocity.y != 0f)
		{
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Sign(rb.velocity.y) * 2f);
		}
        
        if (Mathf.Abs(rb.velocity.x) < 1f && gameOver == false)
		{
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * 1f, rb.velocity.y);
		}
	}

    void ResetBall()
    {
        rb.position = Vector2.zero;
        rb.velocity = Vector2.zero;

        float x = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);
        float y = Random.value < 0.5f ? -1.0f : 1.0f;

        Vector2 direction = new Vector2(x, y);
        rb.AddForce(direction * 100f);
    }

    IEnumerator AddStartingForce()
	{
        float x = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);
        float y = Random.value < 0.5f ? -1.0f : 1.0f;

        Vector2 direction = new Vector2(x, y);

        yield return 0;

        rb.AddForce(direction * this.speed);
    }

    // Update is called once per frame
    public void AddForce(Vector2 force)
	{
        rb.AddForce(force);
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.collider.tag != "Box")
		{
            FindObjectOfType<AudioManager>().Play("Bounce");
		}

        if (collision.collider.tag == "Player")
        {
            score++;
            if (gameMode == "solo")
			{
                PlayerPrefs.SetInt("Score solo", score);
            }
            else if (gameMode == "team")
			{
                PlayerPrefs.SetInt("Score team", score);
            }
            scoreText.text = score.ToString();
        }

        if (collision.collider.tag == "Box")
        {
            if (SwitchToggle.vibration)
            {
                Handheld.Vibrate();
            }

            if (gameMode == "solo")
			{
                if (PlayerPrefs.GetInt("Score solo", 0) > PlayerPrefs.GetInt("Highscore solo", 0))
                {
                    PlayerPrefs.SetInt("Highscore solo", score);
                }
                FindObjectOfType<AudioManager>().Play("Death");
                rb.velocity = Vector2.zero;
                gameOver = true;
                gameOverUI.SetActive(true);
            }
            else if (gameMode == "team")
			{
                if (PlayerPrefs.GetInt("Score team", 0) > PlayerPrefs.GetInt("Highscore team", 0))
                {
                    PlayerPrefs.SetInt("Highscore team", score);
                }
                FindObjectOfType<AudioManager>().Play("Death");
                rb.velocity = Vector2.zero;
                gameOver = true;
                gameOverUI.SetActive(true);
            }
            else if (gameMode == "versus")
            { 
                if (collision.collider.name == "Box Up")
                {
                    P1score++;
                    PlayerPrefs.SetInt("P1 Score", P1score);
                    P1scoreText.text = P1score.ToString();
                }
                else
                {
                    P2score++;
                    PlayerPrefs.SetInt("P2 Score", P2score);
                    P2scoreText.text = P2score.ToString();
                }
                FindObjectOfType<AudioManager>().Play("Death");
                ResetBall();
            }
        }
	}
}
