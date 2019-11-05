using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private float currentSpeed;
    public float damagePerVel = 1f;
    [SerializeField] private float speedForDestroy = 100f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        currentSpeed = rb2d.velocity.magnitude;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (currentSpeed >= speedForDestroy)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("damage: " + currentSpeed * damagePerVel/100f);
                other.gameObject.GetComponent<IController>().GetStatsSystem().TakeDamage(currentSpeed * damagePerVel/100f);
                other.gameObject.GetComponent<EnemyController>().StartCoroutine("Stun");
                Destroy(gameObject);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (currentSpeed >= speedForDestroy)
        {
            if (other.tag == "Wall")
            {
                Debug.Log("trigger");
                Destroy(gameObject);
            }
        }
    }
}
