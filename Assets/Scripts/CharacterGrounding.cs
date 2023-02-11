using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{
    [SerializeField] private Transform leftSensor;
    [SerializeField] private Transform rightSensor;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;

    private Transform groundedObject;
    private Vector3? groundedObjectLastPosition; //Vector3? means that Vector3 can be null in this case

    public bool IsGrounded { get; private set; }

    private void Update()
    {
        CheckSensorForGrounded(leftSensor);

        if (!IsGrounded)
            CheckSensorForGrounded(rightSensor);

        StickToMovingObject();
    }

    private void StickToMovingObject()
    {
        if (groundedObject != null)
        {
            if (groundedObjectLastPosition.HasValue && groundedObjectLastPosition.Value != groundedObject.position)
            {
                Vector3 delta = groundedObject.position - groundedObjectLastPosition.Value;
                transform.position += delta;
            }
            groundedObjectLastPosition = groundedObject.position;
        }
        else
        {
            groundedObjectLastPosition = null;
        }
    }

    private void CheckSensorForGrounded(Transform sensor)
    {
        var raycastHit = Physics2D.Raycast(sensor.position, Vector2.down, maxDistance, layerMask);

        if (raycastHit.collider != null)
        {
            groundedObject = raycastHit.collider.transform;
            IsGrounded = true;
        }
        else
        {
            groundedObject = null;
            IsGrounded = false;
        }
    }
}
