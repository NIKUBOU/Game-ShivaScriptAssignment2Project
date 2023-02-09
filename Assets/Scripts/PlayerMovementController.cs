using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string FIRE1 = "Fire1";

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 350f;

    private new Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis(HORIZONTAL);

        Vector3 movement = new Vector3(horizontal, 0);

        transform.position += movement * Time.fixedDeltaTime * moveSpeed;

        if (Input.GetButtonDown(FIRE1))
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce);
        }
    }
}
