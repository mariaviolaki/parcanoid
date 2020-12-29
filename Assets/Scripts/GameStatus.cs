using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    // Parameters
    [Range(0.1f, 5f)] [SerializeField] float gameSpeed = 0.7f;

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }
}
