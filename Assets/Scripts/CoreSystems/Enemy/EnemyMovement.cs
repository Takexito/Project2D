using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private EnemyController controller;

    public float speed = 5f;
    Transform robot;
    Transform girl;
    Transform target;
    Rigidbody2D rigidbody2d;
    public bool isStop = false; 
    private bool isRotate = false;


    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<EnemyController>();

        robot = GameObject.FindGameObjectWithTag("Player").transform;
        girl = GameObject.FindGameObjectWithTag("Girl").transform;
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStop)
        {
            if (CharacterChange.GetCurrentPlayerTag() == "Player") target = robot;
            else target = girl;
            if (Vector2.Distance(transform.position, target.position) > 1f)
            { 
                Debug.Log(Vector2.Distance(transform.position, target.position));
                Vector2 pos = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                rigidbody2d.MovePosition(pos);
                //Rotate();
            }
        }

    }

    void Rotate()
    {

        if (transform.position.x < target.position.x && !isRotate)
        {
            transform.Rotate(Vector3.up * -180);
            isRotate = true;
        }
        if (transform.position.x > target.position.x && isRotate)
        {
            transform.Rotate(Vector3.up * 180);
            isRotate = false;
        }
    }

    internal void Stop(bool v)
    {
        isStop = v;
        if (!isStop)
        {
            rigidbody2d.velocity = Vector2.zero;
        }
    }
}
