using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : MonoBehaviour
{

    [Header("Сколько регенерирует")]
    public float heal;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<IController>().GetStatsSystem().Heal(heal);
            Destroy(gameObject);
        }
    }
}
