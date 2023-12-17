using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public bool isPlayerHibox;

    void CheckHit(Collider2D collision)
    {
        var tag = isPlayerHibox ? "EnemyAttack" : "PlayerAttack";

        if (collision.tag == tag)
        { 
            GetComponentInParent<Entity>()?.Hurt(collision.GetComponentInParent<Attack>().damage);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckHit(collision);
    }

}
