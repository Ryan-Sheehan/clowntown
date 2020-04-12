using UnityEngine;
using System;
using System.Collections;

public class Player2Controller : MonoBehaviour
{

	private Rigidbody2D rigidBody;

	bool movingLeft;
	bool movingRight;

	private float playerSpeed = 0.1f;
	private float jumpForce = 10f;


	private void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>();
	}

	public void ButtonInput(string input)
	{

		switch (input)
		{
			case "right":
				movingRight = true;
				break;
			case "left":
				movingLeft = true;
				break;
			case "right-up":
				movingRight = false;
				break;
			case "left-up":
				movingLeft = false;
				break;
			case "jump":
				rigidBody.AddForce(transform.up * jumpForce);
				break;
		}
	}

	private void FixedUpdate()
	{
		if (movingLeft && !movingRight)
		{
			rigidBody.MovePosition(rigidBody.position + new Vector2(-playerSpeed, 0));
		}
		else if (!movingLeft && movingRight)
		{
			rigidBody.MovePosition(rigidBody.position + new Vector2(playerSpeed, 0));
		}
	}

	void Update()
	{

		//jump code
		if (Input.GetKey(KeyCode.W))
		{
			rigidBody.AddForce(transform.up * jumpForce);
		}

		if (Input.GetKey(KeyCode.D))
		{
			movingRight = true;
		}
		else
		{
			movingRight = false;
		}

		if (Input.GetKey(KeyCode.A))
		{
			movingLeft = true;
		}
		else
		{
			movingLeft = false;
		}
	}
}