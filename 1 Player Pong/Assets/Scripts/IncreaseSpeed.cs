using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSpeed : MonoBehaviour
{
    public float increasedSpeed = 5f;

	// Start is called before the first frame update
	private void OnCollisionEnter2D(Collision2D collision)
	{
		BallMovement ball = collision.gameObject.GetComponent<BallMovement>();

		if (ball != null)
		{
			Vector2 normal = collision.GetContact(0).normal;
			ball.AddForce(-normal * this.increasedSpeed);
		}
	}
}
