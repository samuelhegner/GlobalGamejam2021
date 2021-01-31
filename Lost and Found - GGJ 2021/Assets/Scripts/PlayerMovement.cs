using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{


    [Header("Component References")]
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject model;

    [Header("Movement Settings")]
    [SerializeField] private float movementSpeed = 3f;
    [SerializeField] private float tiltSpeed = 10f;
    [SerializeField] private float maxTiltAngle = 25f;

    public Vector3 movement;


    Vector3 movementDirection;



    void FixedUpdate()
    {
        movePlayer();
        tiltPlayerInMovementDirection();
    }

    private void tiltPlayerInMovementDirection()
    {
        if (playerRigidbody.velocity.magnitude > 0.1f)
        {
            model.transform.rotation = Quaternion.LookRotation(playerRigidbody.velocity.normalized, Vector3.up);
        }
        float tiltAngle = FloatExtensions.Map(playerRigidbody.velocity.magnitude, 0, movementSpeed, 0, maxTiltAngle);
        Quaternion targetRotation = Quaternion.AngleAxis(tiltAngle, model.transform.right);
        model.transform.rotation = Quaternion.Slerp(model.transform.rotation, targetRotation, tiltSpeed * Time.deltaTime);


    }

    private void movePlayer()
    {
        Vector3 inputDirection = CameraDirection(movementDirection);
        movement = inputDirection * movementSpeed * Time.deltaTime;
        
        playerRigidbody.MovePosition(transform.position + movement);
    }

    public void updateMovementData(Vector3 smoothMovementInput)
    {
        movementDirection = smoothMovementInput;
    }

    Vector3 CameraDirection(Vector3 movementDirection)
    {
        var cameraForward = mainCamera.transform.forward;
        var cameraRight = mainCamera.transform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;
        
        Vector3 direction = cameraForward.normalized * movementDirection.z + cameraRight.normalized * movementDirection.x;
        return Vector3.ProjectOnPlane(direction, Vector3.up);
    }
}