using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private GameObject enemy;
    private float currentSpeed;
    [SerializeField] private float speedForDestroy = 2;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    void Update()
    {
        currentSpeed = rb2d.velocity.magnitude;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (currentSpeed >= speedForDestroy)
        {
            if (other.gameObject == enemy)
            {
                Debug.Log("collision");
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
