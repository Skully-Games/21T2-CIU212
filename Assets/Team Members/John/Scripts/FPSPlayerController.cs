using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class FPSPlayerController : NetworkBehaviour
{
    [Header("Movement")]
    public float movementSpeed;
    
    
    private float horizontalMovement;
    private float verticalMovement;
    private Vector3 moveDirection;
    private Rigidbody rb;
   

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        if (isLocalPlayer)
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal");
            verticalMovement = Input.GetAxisRaw("Vertical");
        }

        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
    }
    private void FixedUpdate()
    {
        rb.AddForce(moveDirection.normalized * movementSpeed, ForceMode.Acceleration);
    }
}
