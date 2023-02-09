using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";

    [SerializeField] float moveSpeed = 5f;

    private void Update()
    {
        float horizontal = Input.GetAxis(HORIZONTAL);

        Vector3 movement = new Vector3(horizontal, 0);

        transform.position += movement * Time.deltaTime * moveSpeed;
    }
}
