using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackSystem: MonoBehaviour
{
    private CharacterStatsSystem statsSystem;
    
    public GameObject[] weapons;
    public float attackSpeedPerSec = 2f;
    public bool isAttack = false;
    public bool isStun = true;
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

    public void AddAtackToQueue(int weaponNum = 0)
    {
        if (!isAttack) 
        {
            Debug.Log(weaponNum);
            if (weaponNum > weapons.Length - 1) weaponNum = 0;
            //gameObject.GetComponent<CharacterController2D>().animator.SetTrigger("IsAttack");
            StartCoroutine("Attack", weaponNum);
            
            startCombo = Time.time;
            attackCheck = false;
        }

    }


    IEnumerator Attack(int weaponNum)
    {
        if (!isStun)
        {
            
            isAttack = true;
            weapons[weaponNum].SetActive(isAttack);
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
            //gameObject.GetComponent<CharacterController2D>().animator.SetBool("IsAttack", false);
            weapons[weaponNum].SetActive(isAttack);

        }
    }
}
