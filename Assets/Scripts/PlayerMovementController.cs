using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour, IMove
{
    private const string HORIZONTAL = "Horizontal";
    private const string FIRE1 = "Fire1";

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 350f;

    private new Rigidbody2D rigidbody2D;
    private CharacterGrounding characterGrounding;
    private Animator animator;

    public float Speed { get; private set; }

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        characterGrounding = GetComponent<CharacterGrounding>();
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        if (Input.GetButtonDown(FIRE1) && characterGrounding.IsGrounded)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce);

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
        float horizontal = Input.GetAxis(HORIZONTAL);
        Speed = horizontal;

        Vector3 movement = new Vector3(horizontal, 0);

        transform.position += movement * Time.fixedDeltaTime * moveSpeed;

    }
}
