using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Range(1.0f, 15.0f)] public float speed = 10f; // Скорость передвижения
    private Rigidbody2D rb2d; // Сам игровой объект

    void Start()
    {    
        rb2d = GetComponent<Rigidbody2D>(); // Инициализируем объект
    }

    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed; // Хранение направления передвижения вправо или влево, умноженное на скорость
        float deltaY = Input.GetAxis("Vertical") * speed; // Хранение направления передвижения вверх или вниз, умноженноое на скорость
        Vector3 movement = new Vector3(deltaX, deltaY, 0); // Создаем переменную в которой будем хранить окончательное направление
        movement = Vector3.ClampMagnitude(movement, speed); // Делаем так чтобы по диагонали скорость была = speed
        movement *= Time.deltaTime;
        rb2d.MovePosition(transform.position + movement); // Движение персонажа 
        if (movement != Vector3.zero && Input.GetKeyUp(KeyCode.Space))
        {
            rb2d.AddForce(new Vector2(deltaX * 1000,deltaY * 1000));
        }
    }
}