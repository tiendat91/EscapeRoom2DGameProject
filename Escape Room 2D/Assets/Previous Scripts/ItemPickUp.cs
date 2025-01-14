using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    Rigidbody2D rb;

    Vector2 heroDirection;
    float timeStamp;
    bool flyToHero;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            timeStamp = Time.time;
            rb.velocity = new Vector2(heroDirection.x, heroDirection.y) * 10f * (Time.time / timeStamp);
        }
    }
}
