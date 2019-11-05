using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem: MonoBehaviour
{
    public GameObject weapon;
    private bool isStop = false;
    public float attackSpeed = 2f;

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
        isStop = false;
        while (!isStop)
        {
            Debug.Log("ATTACK!!!");

            weapon.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            weapon.SetActive(false);
            yield return new WaitForSeconds(1f/attackSpeed);
        }
    }
}
