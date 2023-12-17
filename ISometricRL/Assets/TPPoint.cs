using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TPPoint : MonoBehaviour
{
    public Transform Enemies;
    public string destinationSceneName;

    public bool tpEnabled = false;

    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Enemies.childCount == 0)
        {
            tpEnabled = true;
            sr.color = Color.green;
        } else
        {
            tpEnabled = false;
            sr.color = Color.red;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.tag == "Player" || collision.tag == "PlayerHitbox") && tpEnabled)
        {
            SceneManager.LoadScene(destinationSceneName);
        }
    }
}
