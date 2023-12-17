using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Animator animator;
    private Rigidbody2D rbody;

    public bool isAttacking = false;

    public enum Direction
    {
        Down,
        DownRight,
        Right,
        UpRight,
        Up,
        UpLeft,
        Left,
        DownLeft
    }

    public Direction direction = Direction.Down;

    void Start()
    {
        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();
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
            //transform.position = newPosition;
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

    void PlayRunAnimation()
    {
        animator.Play("Run_" + (int)direction);
    }

    void PlayIdleAnimation()
    {
        animator.Play("Idle_" + (int)direction);
    }

    void PlayAttackAnimation()
    {
       
        animator.Play("Attack_" + (int)direction);
    }

    void OnAttackAnimationStart()
    {
        isAttacking = true;
    }

    void onAttackAnimationEnd()
    {
        isAttacking = false;
    }

    void SetCurrentDirection(float x, float y)
    {
        direction = Direction.Down;
        if (x == 0)
        {
            if (y > 0)
            {
                direction = Direction.Up;
            }
            else if (y < 0)
            {
                direction = Direction.Down;
            }
        }
        else if (y == 0)
        {
            if (x > 0)
            {
                direction = Direction.Right;
            }
            else if (x < 0)
            {
                direction = Direction.Left;
            }
        }
        else
        {
            if (x > 0)
            {
                if (y > 0)
                {
                    direction = Direction.UpRight;
                }
                else if (y < 0)
                {
                    direction = Direction.DownRight;
                }
            }
            else
            {
                if (y > 0)
                {
                    direction = Direction.UpLeft;
                }
                else if (y < 0)
                {
                    direction = Direction.DownLeft;
                }
            }
        }
    }

}
