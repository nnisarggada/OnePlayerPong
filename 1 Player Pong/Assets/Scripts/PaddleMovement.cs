using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb1;
    public Rigidbody2D rb2;
    public bool singleplayer = true;
    public string gameMode;
    public float totTime1;
    public float totTime2;
    public float timeForReset = 5f;
    public Vector2 updatedPos1;
    public Vector2 updatedPos2;

    // Start is called before the first frame update
    void Start()
    {
        gameMode = MenuHandler.gameMode;
        if (gameMode == "solo")
		{
            singleplayer = true;
		}
        else
		{
            singleplayer = false;
		}
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                if (touch.position.y < Screen.height / 2)
                {
                    if (touchPosition.y < rb1.position.y)
                    {
                        if (singleplayer)
                        {
                            rb1.MovePosition(new Vector2(Mathf.Abs(touchPosition.x) < 1.7f ? touchPosition.x : Mathf.Sign(touchPosition.x) * 1.7f, rb1.position.y));
                            rb2.MovePosition(new Vector2(Mathf.Abs(touchPosition.x) < 1.7f ? touchPosition.x : Mathf.Sign(touchPosition.x) * 1.7f, rb2.position.y));
                        }
                        else
                        {
                            rb1.MovePosition(new Vector2(Mathf.Abs(touchPosition.x) < 1.7f ? touchPosition.x : Mathf.Sign(touchPosition.x) * 1.7f, rb1.position.y));
                        }
                    }
                }
                else
                {
                    if (touchPosition.y > rb2.position.y && singleplayer == false)
                    {
                        rb2.MovePosition(new Vector2(Mathf.Abs(touchPosition.x) < 1.7f ? touchPosition.x : Mathf.Sign(touchPosition.x) * 1.7f, rb2.position.y));
                    }
                }
            }
        }
        rb1.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb1.velocity.y);
        rb2.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb2.velocity.y);

        totTime1 += Time.deltaTime;
        totTime2 += Time.deltaTime;

        if (rb1.position == updatedPos1)
		{
            if (totTime1 >= timeForReset)
			{
                rb1.MovePosition(new Vector2(0, rb1.position.y));
                totTime1 = 0f;
			}
		}
        else
		{
            totTime1 = 0f;
		}
        
        if (rb2.position == updatedPos2)
		{
            if (totTime2 >= timeForReset)
			{
                rb2.MovePosition(new Vector2(0, rb2.position.y));
                totTime2 = 0f;
			}
		}
        else
		{
            totTime2 = 0f;
		}

        updatedPos1 = rb1.position;
        updatedPos2 = rb2.position;
    }
}
