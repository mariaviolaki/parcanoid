using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] Paddle paddle;
    [SerializeField] float xVelocity = 2f;
    [SerializeField] float yVelocity = 15f;

    // State
    float distanceToPaddle = 0;
    bool hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        FindDistanceToPaddle();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockToPaddle();
            LaunchOnMouseClick();
        }
    }

    // Calculate distance so that the ball sticks to the paddle
    private void FindDistanceToPaddle()
    {
        // Find ball's and paddle's half height
        float ballHalfHeight = GetComponent<SpriteRenderer>().bounds.extents.y;
        float paddleHalfHeight = paddle.GetComponent<SpriteRenderer>().bounds.extents.y;
        // Store the vertical distance between their centers
        distanceToPaddle = ballHalfHeight + paddleHalfHeight;
    }

    // Move the ball on top of the paddle
    private void LockToPaddle()
    {
        float newYPos = paddle.transform.position.y + distanceToPaddle;
        transform.position = new Vector2(paddle.transform.position.x, newYPos);
    }

    // Push the ball off the paddle to start the game
    private void LaunchOnMouseClick()
    {
        // Check if the player has left-clicked
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity, yVelocity);
        }
    }
}
