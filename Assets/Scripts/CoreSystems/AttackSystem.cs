using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem: MonoBehaviour
{
    public GameObject weapon;
    private bool isStop = false;
    public float attackSpeedPerSec = 2f;
    public bool isAttack = false;
    public bool isStun = false;

    public void StopCoroutine()
    {
        isStop = true;
    }

    public void Change()
    {
        weapon.SetActive(!weapon.activeSelf);
    }

    IEnumerator Attack()
    {
        if (!isStun)
        {
            isStop = false;
            isAttack = true;
            while (!isStop)
            {
                Debug.Log("ATTACK!!!");

                weapon.SetActive(true);
                yield return new WaitForSeconds(1f / attackSpeedPerSec);
                //yield return new WaitForSeconds(0.3f);
                weapon.SetActive(false);

            }
            isAttack = false;
        }
    }
}
