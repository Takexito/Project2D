using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private EnemyController controller;

    public float speed = 5f;
    Transform target;
    Rigidbody2D rigidbody2d;
    private bool isRotate = false;


    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<EnemyController>();

        target = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > 200f && !controller.statsSystem.isStun)
        {
            Vector2 pos = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            rigidbody2d.MovePosition(pos);
            Rotate();
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
}
