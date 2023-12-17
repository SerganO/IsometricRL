using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : Entity
{
    public float moveSpeed = 5f;
    private Rigidbody2D rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleMouseClick();
        HandleMovementInput();
    }

    void HandleMovementInput()
    {
        if (isAttacking) return;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f).normalized;

        if (movement.magnitude > 0.1f)
        {
            SetCurrentDirection(movement.x, movement.y);
            Vector3 newPosition = transform.position + movement * moveSpeed * Time.deltaTime;
            rbody.MovePosition(newPosition);
            PlayRunAnimation();
        }
        else
        {
            PlayIdleAnimation();
        }
    }

    void HandleMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isAttacking) return;
            PlayAttackAnimation();
        }
    }

}
