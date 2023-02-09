using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private const string SPEED = "Speed";

    private Animator animator;
    private IMove iMove;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        iMove = GetComponent<IMove>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float speed = iMove.Speed;
        animator.SetFloat(SPEED, Mathf.Abs(speed));

        if (speed != 0)
            spriteRenderer.flipX = speed < 0;
    }
}
