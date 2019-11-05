using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 10f; // Скорость передвижения
    public Rigidbody2D rb2d; // Сам игровой объект
    public Animator animator;
    private bool isRotate = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Инициализируем объект
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed; // Хранение направления передвижения вправо или влево, умноженное на скорость
        float deltaY = Input.GetAxis("Vertical") * speed; // Хранение направления передвижения вверх или вниз, умноженноое на скорость
        animator.SetFloat("Speed", Mathf.Abs(deltaX));
        Vector3 movement = new Vector3(deltaX, deltaY, 0).normalized; // Создаем переменную в которой будем хранить окончательное направление
        movement *= speed * Time.deltaTime;
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

        rb2d.MovePosition(transform.position + movement); // Движение персонажа 
    }



}
