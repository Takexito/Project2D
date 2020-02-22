using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackSystem: MonoBehaviour
{
    private CharacterStatsSystem statsSystem;
    
    public GameObject weapon;
    public float attackSpeedPerSec = 2f;
    public bool isAttack = false;
    public bool isStun = false;
    public Queue<bool> queue = new Queue<bool>();
    public float timeComboBreak = 5f;
    public int comboCounter;
    public float startCombo;
    public bool attackCheck;
    private float mainRegSt;


    private void Start()
    {
        statsSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStatsSystem>();
        mainRegSt = statsSystem.regenStm;
    }

    public void AddAtackToQueue()
    {
        if (!isAttack) 
        {
            Single.Instance.CharacterController2D.animator.SetTrigger("IsAttack");
            StartCoroutine("Attack");
            startCombo = Time.time;
            attackCheck = false;
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
            if (Time.time - startCombo < timeComboBreak && attackCheck)
            {
                comboCounter++;
                statsSystem.addDmg = comboCounter / 2;
                statsSystem.regenStm += comboCounter;
                /*Debug.Log("CurrAddDmg = " + statsSystem.addDmg);
                Debug.Log("CurrDmg = " + statsSystem.dmg);*/
            }
            else
            {
                statsSystem.regenStm = mainRegSt;
                statsSystem.addDmg = 0;
                comboCounter = 0;
            }
            yield return new WaitForSeconds(1f / attackSpeedPerSec);
            
            isAttack = false;
            Single.Instance.CharacterController2D.animator.SetBool("IsAttack", false);
            weapon.SetActive(isAttack);

        }
    }
}
