using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Update()
    {
        if (IsGameOver())
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("Game Over");
    }

    bool IsGameOver()
    {
        return PlayerStats.Lives <= 0;
    }
}
