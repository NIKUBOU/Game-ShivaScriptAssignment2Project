using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public int Lives { get; private set; }
    public int Deaths { get; private set; }

    public static GameManager Instance { get; private set; }

    public event Action<int> OnLivesChanged;
    public event Action<int> OnCoinsChanged;
    public event Action<int> OnScoreChanged;

    private int coins;
    private int score;
    private int currentLevelIndex;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
        {
            Deaths = 0;
            Instance = this;
            DontDestroyOnLoad(gameObject);

            RestartGame();
        }
    }

    internal void KillPlayer()
    {
        Lives--;
        if (OnLivesChanged != null)
            OnLivesChanged(Lives);

        if (Lives <= 0)
        {
            Deaths++;
            RestartGame();
        }
        else
            SendPlayerTOCheckpoint();
    }

    private void SendPlayerTOCheckpoint()
    {
        var checkpointManager = FindObjectOfType<CheckpointManager>();
        var checkpoint = checkpointManager.GetLastCheckpointThatWasPassed();

        var player = FindObjectOfType<PlayerMovementController>();
        player.transform.position = checkpoint.transform.position;
    }

    internal void AddCoins()
    {
        coins++;

        if (OnCoinsChanged != null)
            OnCoinsChanged(coins);
    }

    public void MoveToNextLevel()
    {
        currentLevelIndex++;
        SceneManager.LoadScene(currentLevelIndex);
    }

    private void RestartGame()
    {
        currentLevelIndex = 0;

        Lives = 3;
        coins = 0;
        score = 0;

        if (OnCoinsChanged != null)
            OnCoinsChanged(coins);

        SceneManager.LoadScene(0);
    }

    internal void AddScore(int points)
    {
        score += points;

        if (OnScoreChanged != null)
            OnScoreChanged(score);
    }

}
