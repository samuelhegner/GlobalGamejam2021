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
            model.transform.rotation = Quaternion.LookRotation(playerRigidbody.velocity, Vector3.up);
        }
        float tiltAngle = FloatExtensions.Map(playerRigidbody.velocity.magnitude, 0, movementSpeed, 0, maxTiltAngle);
        /*Quaternion targetRotation = Quaternion.Euler(0 + tiltAngle
                                                      , model.transform.rotation.eulerAngles.y
                                                      , model.transform.rotation.eulerAngles.z);*/
        Quaternion targetRotation = Quaternion.AngleAxis(tiltAngle, model.transform.right);
        model.transform.rotation = Quaternion.Slerp(model.transform.rotation, targetRotation, tiltSpeed * Time.deltaTime);


    }

    private void movePlayer()
    {
        Vector3 movement = CameraDirection(movementDirection) * movementSpeed * Time.deltaTime;
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

        return cameraForward * movementDirection.z + cameraRight * movementDirection.x;

    }
}