using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private const string SPEED = "Speed";

    private Animator animator;
    private PlayerMovementController _playerMovementController;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        _playerMovementController = GetComponent<PlayerMovementController>();
    }

    private void Update()
    {
        float speed = _playerMovementController.Speed;
        animator.SetFloat(SPEED, speed);
    }
}
