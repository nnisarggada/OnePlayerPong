using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBall : MonoBehaviour
{

    public float speed = 200f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        float x = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);
        float y = Random.value < 0.5f ? -1.0f : 1.0f;
        Vector2 direction = new Vector2(x, y);
        rb.AddForce(direction * this.speed);
    }
}