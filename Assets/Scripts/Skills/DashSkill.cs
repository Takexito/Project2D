using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill : MonoBehaviour, ISkills
{
    public float coolDown = 2;
    public float coolDownEnd = 0;
    public float dashForce = 3f;
    public void UseSkill()
    {
        if (Time.time > coolDownEnd)
        {
            coolDownEnd = Time.time + coolDown;
            StartCoroutine(DashMove()); // Использование корутины для рывка
        }
    }

    IEnumerator DashMove()
    {
        CharacterMovement movement = GameObject.FindGameObjectsWithTag("Player")[0]
            .GetComponent<CharacterController2D>().movement;

        //if (time <= 0)  для КД
        //{
        // Функция рывка
        transform.Rotate(Vector3.forward * -90);
        movement.speed *= dashForce;
        yield return new WaitForSeconds(0.1f); // Задержка выполнения следующего шага
        transform.Rotate(Vector3.forward * 90);
        movement.speed /= dashForce;

        // time = 2f; // Возвращение времени счётчика
        //}
    }

}
