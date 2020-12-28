using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound = default;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Keep playing sound effect even after the block is destroyed
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 0.1f);
        Destroy(gameObject);
    }
}
