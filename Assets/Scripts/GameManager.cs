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

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
        {
            Lives = 3;
            Deaths = 0;
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    internal void KillPlayer()
    {
        Lives--;
        SceneManager.LoadScene(0);
    }
}
