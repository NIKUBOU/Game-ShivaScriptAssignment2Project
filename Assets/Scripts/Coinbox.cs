using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinbox : MonoBehaviour
{
    private const string COINSPIN = "CoinSpin";
    
    [SerializeField] private SpriteRenderer enabledSprite;
    [SerializeField] private SpriteRenderer disabledSprite;
    [SerializeField] private int totalCoins = 1;

    private int remainingCoins;
    private Animator animator;


    private void Awake()
    {
        remainingCoins = totalCoins;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (remainingCoins > 0 &&
            WasHitByPlayer(collision) &&
            WasHitFromBelow(collision))
        {
            GameManager.Instance.AddCoins();
            remainingCoins--;
            animator.SetTrigger(COINSPIN);

            if (remainingCoins <= 0)
            {
                enabledSprite.enabled = false;
                disabledSprite.enabled = true;
            }
        }
    }

    private static bool WasHitByPlayer(Collision2D collision)
    {
        return collision.collider.GetComponent<PlayerMovementController>() != null;
    }

    private static bool WasHitFromBelow(Collision2D collision)
    {
        return collision.contacts[0].normal.y > 0.5;
    }
}
