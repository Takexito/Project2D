using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill : MonoBehaviour, ISkills
{
    public float dashForce = 3f;
    public void UseSkill()
    {
        StartCoroutine(DashMove()); // Использование корутины для рывка
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
