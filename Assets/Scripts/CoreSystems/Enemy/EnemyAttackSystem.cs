using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackSystem : MonoBehaviour
{

    private EnemyController controller;

    public GameObject weapon;
    
    public float attackSpeedPerSec = 2f;
    public bool isAttack = false;
    public bool isStop = false;
    // Start is called before the first frame update
    public void AddAtackToQueue()
    {
        if (!isAttack) StartCoroutine("Attack");
    }
    public void Change()
    {
        weapon.SetActive(!weapon.activeSelf);
    }

    IEnumerator Attack()
    {
        if (!controller.statsSystem.isStun)
        {
            if (!isStop)
            {
                isAttack = true;
                Debug.Log("ATTACK!!!");

                weapon.SetActive(true);
                yield return new WaitForSeconds(1f / attackSpeedPerSec);
                weapon.SetActive(false);
                //Single.Instance.CharacterController2D.movement.MoveAfterHit();
                isAttack = false;
                yield return new WaitForSeconds(1f);
                StartCoroutine(Attack());
            }
        }
    }

    public void StopCoroutine()
    {
        isStop = true;
    }

    private void Start()
    {
        controller = gameObject.GetComponent<EnemyController>();
    }
}
