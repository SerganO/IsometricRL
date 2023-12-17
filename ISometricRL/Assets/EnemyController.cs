using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : Entity
{


    public Transform goal;
    NavMeshAgent agent;

    public float VisionRadius = 5.0f;
    public bool goalSetted = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateUpAxis = false;
        agent.updateRotation = false;
        transform.rotation = new Quaternion();
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    private void Update()
    {
        GetComponent<Rigidbody2D>().WakeUp();
        if (attackCountDown > 0)
        {
            attackCountDown -= Time.deltaTime;
        }
        else
        {
            attackCountDown = 0;
        }
        agent.isStopped = moveDisabled;
        if (moveDisabled || !actionEnabled) return;
        goal = GameObject.FindGameObjectWithTag("Player").transform;
        if(goalSetted || Vector2.Distance(transform.position, goal.position) <= VisionRadius)
        {
            goalSetted = true;
            agent.destination = goal.position;
        } else
        {
            PlayIdleAnimation();
            return;
        }
       
        var a = agent.path.corners[agent.path.corners.Length - 1];
        var x = a.x - transform.position.x;
        if(Mathf.Abs(x) < 0.05)
        {
            x = 0;
        }

        var y = a.y - transform.position.y;
        if (Mathf.Abs(y) < 0.05)
        {
            y = 0;
        }
        SetCurrentDirection(x, y);
        float velocity = agent.velocity.magnitude / agent.speed;
        if(velocity > 0)
        {

            PlayRunAnimation();
        } else
        {
            PlayIdleAnimation();
            if(Vector2.Distance(transform.position, goal.position) < 0.5)
            {
                if (!isHurting && !isAttacking && attackCountDown <= 0)
                {
                    PlayAttackAnimation();
                }
                  

            }
           
        }

       
       
    }
}
