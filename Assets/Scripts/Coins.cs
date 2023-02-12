using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.AddCoins();
        GameManager.Instance.AddScore(100);
        gameObject.SetActive(false);
    }
}
