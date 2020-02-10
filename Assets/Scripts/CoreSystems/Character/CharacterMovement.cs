using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 10f; // Скорость передвижения
    public Rigidbody2D rb2d; // Сам игровой объект
    private Animator animator;
    private bool isRotate = false;
    private bool moveAtack = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Инициализируем объект
        animator = Single.Instance.CharacterController2D.animator;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) Movement();
        else animator.SetFloat("Speed", Mathf.Abs(0));
        if (moveAtack)
        {
            MoveCharacter(transform.right.x, 0f);
            moveAtack = false;
        }
    }

    private void Movement()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed; // Хранение направления передвижения вправо или влево, умноженное на скорость
        float deltaY = Input.GetAxis("Vertical") * speed; // Хранение направления передвижения вверх или вниз, умноженноое на скорость
        animator.SetFloat("Speed", Mathf.Abs(deltaX));
        if (deltaX < 0 && !isRotate)
        {
            transform.Rotate(Vector3.up * -180);
            isRotate = true;
        }
        if (deltaX > 0 && isRotate)
        {
            transform.Rotate(Vector3.up * 180);
            isRotate = false;
        }
        MoveCharacter(deltaX, deltaY);
    }


    public void MoveCharacter(float dX, float dY)
    {
        Vector3 movement = new Vector3(dX, dY, 0).normalized; // Создаем переменную в которой будем хранить окончательное направление
        movement *= speed * Time.deltaTime;
        rb2d.MovePosition(transform.position + movement); // Движение персонажа 

    }

    public void MoveCharacter(Vector3 vector)
    {
        rb2d.MovePosition(transform.position + vector); // Движение персонажа 
        Vector3 v3 = transform.position + vector;
        Debug.Log("Move" + v3);
    }

    public void MoveToPoint(Vector2 point)
    {
        rb2d.MovePosition(point);
        Debug.Log("Move" + point);
    }
    public void MoveAfterHit()
    {
        moveAtack = true;

    }

}
