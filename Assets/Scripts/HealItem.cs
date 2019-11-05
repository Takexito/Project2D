using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : MonoBehaviour
{
    Health health;
    public GameObject obj;

    [Header("Сколько регенерирует")]
    public float heal;
    void Start()
    {
        health = obj.GetComponent<Health>(); // Ссылка на 'Health'
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            health.curHealth += heal;
            Destroy(gameObject);
        }
    }
}
