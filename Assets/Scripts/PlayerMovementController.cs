using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour, IMove
{
    private const string HORIZONTAL = "Horizontal";
    private const string FIRE1 = "Fire1";

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 350f;
    [SerializeField] private float runSpeed = 3f;
    [SerializeField] GameObject retryScreen;

    private  Rigidbody2D _rigidbody2D;
    private CharacterGrounding characterGrounding;
    private Animator animator;
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;

    public float Speed { get; private set; }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        characterGrounding = GetComponent<CharacterGrounding>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        PlayerJump();
        OnPlayerDeath();

    }

    private void PlayerJump()
    {
        if (Input.GetButtonDown(FIRE1) && characterGrounding.IsGrounded)
        {
            _rigidbody2D.AddForce(Vector2.up * jumpForce);
            audioSource.Play();

        }

        if (!characterGrounding.IsGrounded)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

    private void FixedUpdate()
    {
        PlayerMovement();

    }

    private void PlayerMovement()
    {
        float horizontal = Input.GetAxis(HORIZONTAL);
        Speed = horizontal;

        Vector3 movement = new Vector3(horizontal, 0);

        transform.position += movement * Time.fixedDeltaTime * moveSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += movement * Time.fixedDeltaTime * moveSpeed * runSpeed;
        }
    }

    private void OnPlayerDeath()
    {
        if (GameManager.Instance.Lives <= 0)
        {
            spriteRenderer.enabled = false;
            this.enabled = false;
            characterGrounding.enabled = false;
            retryScreen.SetActive(true);
        }
    }
}
