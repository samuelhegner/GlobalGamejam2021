using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerTractorBeam playerTractorBeam;

    [Header("Player Input Settings")]
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private float movementSmoothingSpeed = 1f;
    private Vector3 rawInputMovement;
    private Vector3 smoothInputMovement;

    public void OnMove(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        rawInputMovement = new Vector3(inputMovement.x, 0, inputMovement.y);
    }

    public void OnPickUp(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            playerTractorBeam.setBeamState();
        }
        
    }

    void Update()
    {
        CalculateMovementInputSmoothing();
        UpdatePlayerMovement();
    }

    private void CalculateMovementInputSmoothing()
    {
        smoothInputMovement = Vector3.Lerp(smoothInputMovement, rawInputMovement, Time.deltaTime * movementSmoothingSpeed);
    }

    void UpdatePlayerMovement()
    {
        playerMovement.updateMovementData(smoothInputMovement);
    }
}
