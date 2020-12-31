using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    bool isDestroyed = false;

    // Configuation parameters
    [SerializeField] AudioClip breakSound = default;
    [SerializeField] GameObject sparklesVFX = default;

    // Cached references
    Level level;
    GameSession gameStatus;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameSession>();
        level.AddBlock();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If collision happens more than once, avoid executing the same code
        if (!isDestroyed)
        {
            TriggerEffects();
            CalculatePoints();
            DestroyBlock();
        }
    }

    private void DestroyBlock()
    {
        isDestroyed = true;
        Destroy(gameObject);
    }

    private void CalculatePoints()
    {
        // Decrease the total number of blocks by 1
        level.RemoveBlock();

        // Add a block's points to the total score
        gameStatus.IncreaseScore();
    }

    private void TriggerEffects()
    {
        // Display particle effects on the block's position
        GameObject sparkles = Instantiate(sparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);

        // Keep playing sound effect even after the block is destroyed
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 0.1f);
    }
}
