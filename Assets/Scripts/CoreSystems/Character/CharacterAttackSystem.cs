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
            StartCoroutine("Attack");
            Single.Instance.CharacterController2D.animator.SetBool("IsAttack", true);
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
            Debug.Log("ATTACK!!!");
                
            weapon.SetActive(true);
            yield return new WaitForSeconds(1f / attackSpeedPerSec);
            weapon.SetActive(false);
            Single.Instance.CharacterController2D.movement.MoveAfterHit();
            isAttack = false;
            Single.Instance.CharacterController2D.animator.SetBool("IsAttack", false);

        }
    }
}
