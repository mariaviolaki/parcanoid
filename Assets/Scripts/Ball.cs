using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] Paddle paddle;

    // State
    float ballToPaddleDistance;

    // Start is called before the first frame update
    void Start()
    {
        // Find ball's and paddle's half height
        float ballHalfHeight = GetComponent<SpriteRenderer>().bounds.extents.y;
        float paddleHalfHeight = paddle.GetComponent<SpriteRenderer>().bounds.extents.y;
        // Store the vertical distance between their centers
        ballToPaddleDistance = ballHalfHeight + paddleHalfHeight;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the ball so that it's on top of the paddle
        float newYPos = paddle.transform.position.y + ballToPaddleDistance;
        transform.position = new Vector2(paddle.transform.position.x, newYPos);
    }
}
