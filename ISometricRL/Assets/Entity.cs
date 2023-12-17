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
    public Transform Attacks;
    public float attackCountDown = 0;

    public int HitPoint = 10;


    public bool moveDisabled = false;
    public bool actionEnabled = true;
    public bool isAttacking = false;
    public bool isHurting = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void OnAttackAnimationStart()
    {
        moveDisabled = true;
        isAttacking = true;
        Attacks.GetChild((int)direction).gameObject.SetActive(true);
    }

    void onAttackAnimationEnd()
    {
        moveDisabled = false;
        isAttacking = false;
        Attacks.GetChild((int)direction).gameObject.SetActive(false);
        attackCountDown = Attacks.GetChild((int)direction).GetComponentInParent<Attack>().countdown;
    }

    void OnGotHitAnimationStart()
    {
        isHurting = true;
        isAttacking = false;
        moveDisabled = true;
    }

    void onGotHitAnimationEnd()
    {
        isHurting = false;
        moveDisabled = false;
    }

    public void Hurt(int damage)
    {
        HitPoint -= damage;
        if(HitPoint <= 0)
        {
            Death();
            return;
        }
        PlayHurtAnimation();
    }

    void Death()
    {
        moveDisabled = true;
        actionEnabled = false;
        PlayDeathAnimation();
        
    }

    public virtual void onDeath()
    {
        Destroy(this.gameObject);
    }

    public void onDeathAnimationEnd()
    {
        onDeath();
    }

    protected void PlayDeathAnimation()
    {
        animator.Play("Death_" + (int)direction);
    }

    protected void PlayRunAnimation()
    {
        animator.Play("Run_" + (int)direction);
    }

    protected void PlayHurtAnimation()
    {
        animator.Play("GotHit_" + (int)direction);
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
