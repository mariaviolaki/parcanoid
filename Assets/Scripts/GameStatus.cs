using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    // Configuration parameters
    [Range(0.1f, 5f)] [SerializeField] float gameSpeed = 0.7f;
    [SerializeField] int pointsPerBlock = 100;
    [SerializeField] TextMeshProUGUI scoreText = default;

    // State
    int currentScore = 0;

    private void Start()
    {
        updateScoreText();
    }

    private void Update()
    {
        Time.timeScale = gameSpeed;
        updateScoreText();
    }

    // Increases current score every time a block is destroyed
    public void IncreaseScore()
    {
        currentScore += pointsPerBlock;
    }

    private void updateScoreText()
    {
        scoreText.text = currentScore.ToString();
    }
}
