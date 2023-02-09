using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterGrounding))]
public class PlayerMovementController : MonoBehaviour, IMove
{
    private const string HORIZONTAL = "Horizontal";
    private const string JUMP = "Jump";

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 400f;

    private new Rigidbody2D rigidbody2D;
    private CharacterGrounding characterGrounding;

    public float Speed { get; private set; }

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        characterGrounding = GetComponent<CharacterGrounding>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis(HORIZONTAL);
        Speed = horizontal;

        Vector3 movement = new Vector3(horizontal, 0, 0);

        transform.position += movement * Time.fixedDeltaTime * moveSpeed;


        if (Input.GetButton(JUMP) && characterGrounding.IsGrounded)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce);
        }
    }
}
