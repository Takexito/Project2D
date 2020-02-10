using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackSystem: MonoBehaviour
{
    public GameObject weapon;
    public float attackSpeedPerSec = 2f;
    public bool isAttack = false;
    public bool isStun = false;
    public Queue<bool> queue = new Queue<bool>();



    public void AddAtackToQueue()
    {
        if (!isAttack) 
        {
            Single.Instance.CharacterController2D.animator.SetTrigger("IsAttack");
            StartCoroutine("Attack");
            
        }

    }
    public void Change()
    {
        weapon.SetActive(!weapon.activeSelf);
    }

    IEnumerator Attack()
    {
        if (!isStun)
        {
            
            isAttack = true;
            weapon.SetActive(isAttack);
            Single.Instance.CharacterController2D.movement.MoveAfterHit();
            yield return new WaitForSeconds(1f / attackSpeedPerSec);
            
            isAttack = false;
            Single.Instance.CharacterController2D.animator.SetBool("IsAttack", false);
            weapon.SetActive(isAttack);

        }
    }
}
