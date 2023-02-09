using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{
    [SerializeField] private Transform leftSensor;
    [SerializeField] private Transform rightSensor;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;

    public bool IsGrounded { get; private set; }

    private void Update()
    {
        CheckSensorForGrounded(leftSensor);

        if (!IsGrounded)
            CheckSensorForGrounded(rightSensor);
    }

    private void CheckSensorForGrounded(Transform sensor)
    {
        var raycastHit = Physics2D.Raycast(sensor.position, Vector2.down, maxDistance, layerMask);
        if (raycastHit.collider != null)
            IsGrounded = true;
        else
            IsGrounded = false;
    }
}
