using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
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
    protected Animator animator;
    public Direction direction = Direction.Down;

    public bool isAttacking = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void OnAttackAnimationStart()
    {
        isAttacking = true;
    }

    void onAttackAnimationEnd()
    {
        isAttacking = false;
    }

  
    protected void PlayRunAnimation()
    {
        animator.Play("Run_" + (int)direction);
    }

    protected void PlayIdleAnimation()
    {
        animator.Play("Idle_" + (int)direction);
    }

    protected void PlayAttackAnimation()
    {

        animator.Play("Attack_" + (int)direction);
    }

    protected void SetCurrentDirection(float x, float y)
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
