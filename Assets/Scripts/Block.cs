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

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If collision happens more than once, avoid executing the same code
        if (!isDestroyed && tag == "Breakable")
        {
            TriggerEffects();
            CalculatePoints();
            DestroyBlock();
        }
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();

        // Only keep track of breakable blocks to proceed to the next level
        if (tag == "Breakable")
            level.AddBlock();
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
        FindObjectOfType<GameSession>().IncreaseScore();
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
