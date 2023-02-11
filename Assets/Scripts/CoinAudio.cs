using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAudio : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        // When the parameter (coins) is registered do audioSource.Play()
        GameManager.Instance.OnCoinsChanged += (coins) => audioSource.Play();
    }
}
