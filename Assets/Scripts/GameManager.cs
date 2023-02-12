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
    public int Coins { get; private set; }
    public int Scores { get; private set; }
    public float Timer { get; private set; }

    public static GameManager Instance { get; private set; }

    public event Action<int> OnLivesChanged;
    public event Action<int> OnCoinsChanged;
    public event Action<int> OnScoreChanged;
    public event Action<int> OnDeathsChanged;
    public event Action<float> OnTimerChanged;

    private int currentLevelIndex;
    private bool isTimerOn;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
        {
            Deaths = 0;
            Coins = 0;
            Scores = 0;
            Timer = 0;
            Instance = this;
            DontDestroyOnLoad(gameObject);

            RestartGame();
        }
    }

    private void Update()
    {
        CountTime();

    }

    public void CountTime()
    {
        if (currentLevelIndex < 1 || currentLevelIndex >= 4)
        {
            isTimerOn = false;
        }
        else
        {
            isTimerOn = true;
            if (isTimerOn)
                Timer += Time.deltaTime;

            OnTimerChanged?.Invoke(Timer);
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
            if (OnDeathsChanged != null)
                OnDeathsChanged(Deaths);
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
        Coins++;

        if (OnCoinsChanged != null)
            OnCoinsChanged(Coins);
    }

    public void MoveToNextLevel()
    {
        currentLevelIndex++;
        SceneManager.LoadScene(currentLevelIndex);
    }

    public void RestartGame()
    {
        Lives = 3;
        Coins = 0;
        Scores = 0;

        if (OnCoinsChanged != null)
            OnCoinsChanged(Coins);

        SceneManager.LoadScene(currentLevelIndex);

    }

    private void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    internal void AddScore(int points)
    {
        Scores += points;

        OnScoreChanged?.Invoke(Scores);
    }

}
