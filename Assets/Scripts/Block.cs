using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Parameters
    [SerializeField] AudioClip breakSound = default;

    // Cached references
    Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.AddBlock();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        // Keep playing sound effect even after the block is destroyed
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 0.1f);
        level.RemoveBlock();
        Destroy(gameObject);
    }
}
