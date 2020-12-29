using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // Parameters 
    [SerializeField] int breakableBlocks = 0; // for debugging purposes

    // Cached references
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void AddBlock()
    {
        breakableBlocks++;
    }

    public void RemoveBlock()
    {
        breakableBlocks--;

        if (breakableBlocks == 0)
            sceneLoader.LoadNextScene();
    }
}
