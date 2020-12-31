using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    bool isDestroyed = false;

    // Configuation parameters
    [SerializeField] AudioClip breakSound = default;

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
            DestroyBlock();
    }

    private void DestroyBlock()
    {
        // Keep playing sound effect even after the block is destroyed
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 0.1f);
        level.RemoveBlock();
        gameStatus.IncreaseScore();
        isDestroyed = true;
        Destroy(gameObject);
    }
}
