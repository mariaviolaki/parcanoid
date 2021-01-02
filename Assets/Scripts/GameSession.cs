using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    // Configuration parameters
    [Range(0.1f, 5f)] [SerializeField] float gameSpeed = 0.6f;
    [SerializeField] int pointsPerBlock = 100;
    [SerializeField] TextMeshProUGUI scoreText = default;

    // State
    int currentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        // Check if any other GameSession objects are already loaded
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreText();
    }

    private void Update()
    {
        Time.timeScale = gameSpeed;
        UpdateScoreText();
    }

    // Increases current score every time a block is destroyed
    public void IncreaseScore()
    {
        currentScore += pointsPerBlock;
    }

    // Destroy persistent data when the game restarts
    public void ResetGame()
    {
        Destroy(gameObject);
    }

    private void UpdateScoreText()
    {
        scoreText.text = currentScore.ToString();
    }
}
