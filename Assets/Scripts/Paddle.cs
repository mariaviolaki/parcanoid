using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] float screenWidthUnits = 16f;
    float minXUnits;
    float maxXUnits;

    // Cached references
    GameSession gameSession;
    Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
        SetScreenBounds();
    }

    // Make paddle fit exactly inside the screen (x-axis)
    private void SetScreenBounds()
    {
        // Get width of the paddle
        float width = GetComponent<SpriteRenderer>().bounds.size.x;
        // Set min & max x position the paddle can reach
        minXUnits = width / 2;
        maxXUnits = screenWidthUnits - (width / 2);
    }

    // Update is called once per frame
    void Update()
    {
        // Limit value range in x axis so that the paddle stays inside the screen
        float limitedXPos = Mathf.Clamp(GetXPos(), minXUnits, maxXUnits);
        // Set paddle's position to the new x and the current y
        transform.position = new Vector2(limitedXPos, transform.position.y);
    }

    private float GetXPos()
    {
        // Find current position of mouse in the window and store x axis
        float mousePos = Input.mousePosition.x / Screen.width * screenWidthUnits;

        // If autoplay is on, return the ball's x position instead of the mouse's
        if (gameSession.IsAutoEnabled())
            return ball.transform.position.x;
        else
            return mousePos;
    }
}
