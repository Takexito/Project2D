using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    [SerializeField]
    private float speed = 10f; // Скорость передвижения
    [Range(0, .3f)] [SerializeField] private float smoothing = .05f;
    //public float moveForce = 500f;
    private Rigidbody2D rb2d; // Сам игровой объект
    private Animator animator;
    private bool isRotate = false;
    private bool moveAtack = false;
    private Vector2 velocity = Vector2.zero;

    public float Speed { get => speed; set => speed = value; }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = Single.Instance.CharacterController2D.animator;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Movement(h, v);
        if (rb2d.velocity.x == 0 && rb2d.velocity.y == 0) Stop();
        if (moveAtack)
        {
            MoveCharacter(transform.right.x, 0f);
            moveAtack = false;
        }
    }

    private void Movement(float h, float v)
    {
        float deltaX = h * speed; // Хранение направления передвижения вправо или влево, умноженное на скорость
        float deltaY = v * speed; // Хранение направления передвижения вверх или вниз, умноженноое на скорость
        animator.SetFloat("Speed", Mathf.Abs(deltaX));

        if (deltaX < 0 && !isRotate)
            Flip();
        if (deltaX > 0 && isRotate)
            Flip();

        MoveCharacter(deltaX, deltaY);
    }


    public void Stop()
    {
        rb2d.velocity = Vector2.zero;
        animator.SetFloat("Speed", Mathf.Abs(0));
    }

    public void Flip()
    {
        
        isRotate = !isRotate;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        
    }

    public void MoveCharacter(float dX, float dY)
    {
        Vector2 movement = new Vector2(dX, dY); // Создаем переменную в которой будем хранить окончательное направление
        //movement *= moveForce * Time.deltaTime;
        movement *= speed * Time.deltaTime;
        //rb2d.AddForce(movement);
        rb2d.velocity = Vector2.SmoothDamp(rb2d.velocity, movement, ref velocity, smoothing);

        //if (rb2d.velocity.x >= speed) rb2d.velocity = new Vector2 (speed, rb2d.velocity.y);
        //if (rb2d.velocity.x <= -speed) rb2d.velocity = new Vector2 (-speed, rb2d.velocity.y);
        //if (rb2d.velocity.y >= speed) rb2d.velocity = new Vector2(rb2d.velocity.x, speed);
        //if (rb2d.velocity.y <= -speed) rb2d.velocity = new Vector2(rb2d.velocity.x, -speed);

        //rb2d.MovePosition(transform.position + movement); // Движение персонажа 

    }

    public void MoveToPoint(Vector2 point)
    {
        rb2d.MovePosition(point);
        Debug.Log("Move" + point);
    } 
    public void Move(Vector2 direction)
    {
        rb2d.MovePosition(direction);
        Debug.Log("Move" + direction);
    }
    public void MoveAfterHit()
    {
        //moveAtack = true;
        transform.Translate(transform.right * 20f);
    }

}
