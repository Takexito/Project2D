using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 10f; // Скорость передвижения
    public float dashForce = 3f; // Во сколько раз увеличивается скорость при использовании рывка
    private Rigidbody2D rb2d; // Сам игровой объект
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Инициализируем объект
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space)) Dash();
    }

    private void Movement()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed; // Хранение направления передвижения вправо или влево, умноженное на скорость
        float deltaY = Input.GetAxis("Vertical") * speed; // Хранение направления передвижения вверх или вниз, умноженноое на скорость
        Vector3 movement = new Vector3(deltaX, deltaY, 0).normalized; // Создаем переменную в которой будем хранить окончательное направление
        movement *= speed * Time.deltaTime;
        rb2d.MovePosition(transform.position + movement); // Движение персонажа 
    }
    private void Dash()
    {

        StartCoroutine("DashMove"); // Использование корутины для рывка

    }
    IEnumerator DashMove()
    {
        //if (time <= 0)  для КД
        //{
        // Функция рывка
        speed *= dashForce;
        yield return new WaitForSeconds(0.1f); // Задержка выполнения следующего шага
        speed /= dashForce;
        // time = 2f; // Возвращение времени счётчика
        //}
    }

}
