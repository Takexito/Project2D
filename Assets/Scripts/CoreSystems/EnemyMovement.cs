using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;
    Transform target;
    Rigidbody2D rigidbody2d;
    public bool isStop = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > 3f && !isStop)
        {
            Vector2 pos = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            rigidbody2d.MovePosition(pos);
        }
    }

}
