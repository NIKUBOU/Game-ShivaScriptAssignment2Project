using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Lives { get; private set; }
    public int Deaths { get; private set; }

    public static GameManager Instance { get; private set; }

    public event Action<int> OnLivesChanged;
    public event Action<int> OnCoinsChanged;

    private int coins;

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
    }
    internal void AddCoins()
    {
        coins++;

        if (OnCoinsChanged != null)
            OnCoinsChanged(coins);
    }

    private void RestartGame()
    {
        Lives = 3;
        coins = 0;

        if (OnCoinsChanged != null)
            OnCoinsChanged(coins);

        SceneManager.LoadScene(0);
    }

}
