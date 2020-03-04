using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill : MonoBehaviour, ISkills
{
    public float coolDown = 2;
    public float coolDownEnd = 0;
    public float dashForce = 2f;
    public void UseSkill()
    {
        if (Time.time > coolDownEnd)
        {
            coolDownEnd = Time.time + coolDown;
            StartCoroutine(DashMove()); // Использование корутины для рывка
            //Single.Instance.CharacterController2D.animator.SetBool("IsJump", true);
        }
    }

    IEnumerator DashMove()
    {
        CharacterMovement movement = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>().movement;

        transform.Rotate(Vector3.forward * -90);
        movement.Speed *= dashForce;
        yield return new WaitForSeconds(0.1f); // Задержка выполнения следующего шага
        transform.Rotate(Vector3.forward * 90);
        movement.Speed /= dashForce;
        //Single.Instance.CharacterController2D.animator.SetBool("IsJump", false);
    }

}
