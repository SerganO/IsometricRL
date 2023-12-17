using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decor : MonoBehaviour
{
    SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "HideBox")
        {
            sr.sortingOrder = 30;
            sr.color = new Color(1, 1, 1, 0.5f);
        }
       

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "HideBox")
        {
            sr.sortingOrder = 30;
            sr.color = new Color(1, 1, 1, 0.5f);
        }
           
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "HideBox")
        {
            sr.sortingOrder = 1;
            sr.color = new Color(1, 1, 1, 1);
        }
          
    }
}
