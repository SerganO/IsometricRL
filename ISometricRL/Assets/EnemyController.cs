using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : Entity
{


    public Transform goal;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateUpAxis = false;
        agent.updateRotation = false;
        transform.rotation = new Quaternion();
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        goal = GameObject.FindGameObjectWithTag("Player").transform;
        agent.destination = goal.position;
    }

    private void Update()
    {
        goal = GameObject.FindGameObjectWithTag("Player").transform;
        agent.destination = goal.position;
        var a = agent.path.corners[agent.path.corners.Length - 1];
        var angle = Vector2.Angle(transform.position,a);
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
        }

       
       
    }
}
