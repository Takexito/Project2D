using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOnRange : MonoBehaviour
{

    bool isAttack = false;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player") && !isAttack)
        {
            isAttack = true;
            Debug.Log("Enter!!!");
            transform.root.gameObject.GetComponent<IController>().GetAttackSystem().StartCoroutine("Attack");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Exit!!!");
            transform.root.gameObject.GetComponent<IController>().GetAttackSystem().StopCoroutine();
            isAttack = false;
        }
    }
}
