using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_camera : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [Header("Follow Settings")]
    [SerializeField] private float smoothSpeed = 5f;
    [SerializeField] private Vector3 offset;

    [Header("Axis Control")]
    [SerializeField] private bool followX = true;
    [SerializeField] private bool followY = false;

    void LateUpdate()
    {
        // Safety check
        Vector3 targetPosition = transform.position;


        if (followX)
        {
            targetPosition.x = _target.position.x + offset.x;
        }


        if (followY)
        {
            targetPosition.y = _target.position.y + offset.y;
        }
            

        targetPosition.z = transform.position.z; // keep camera depth

        // Smooth movement
        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            smoothSpeed * Time.deltaTime
        );
    }
}