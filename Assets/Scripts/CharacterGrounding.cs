using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{
    [SerializeField] private Transform leftSensor;
    [SerializeField] private Transform rightSensor;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;
    private bool isGrounded;

    private void Update()
    {
        CheckSensorForGrounded(leftSensor);

        if (!isGrounded)
            CheckSensorForGrounded(rightSensor);
    }

    private void CheckSensorForGrounded(Transform sensor)
    {
        var raycastHit = Physics2D.Raycast(sensor.position, Vector2.down, maxDistance, layerMask);
        if (raycastHit.collider != null)
            isGrounded = true;
        else
            isGrounded = false;
    }
}
