using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] float screenWidthUnits = 16f;
    float minXUnits;
    float maxXUnits;

    // Start is called before the first frame update
    void Start()
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
        // Find current position of mouse in the window and store x axis
        float xPos = Input.mousePosition.x / Screen.width * screenWidthUnits;
        // Limit value range in x axis so that the paddle stays inside the screen
        float limitedXPos = Mathf.Clamp(xPos, minXUnits, maxXUnits);
        // Set paddle's position to the new x and the current y
        transform.position = new Vector2(limitedXPos, transform.position.y);
    }
}
