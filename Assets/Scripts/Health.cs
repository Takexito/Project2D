using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("Игрок")]
    public GameObject Player;

    [Header("Текущее здоровье")]
    public float curHealth = 100;

    [Header("Хилка")]
    public GameObject HealItem;

    public float heal = 25;

    [Header("HealthBar")]
    public GameObject healthObject;

    [Header("HP")]
    public Text healthText;

    void Update()
    {
        healthObject.transform.localScale = new Vector2(curHealth / 100, 1); // Сдвиг полоски HealtBar
        healthText.text = curHealth.ToString("0"); // Изменение числа HP

        if (curHealth >= 100)
        {
            curHealth = 100;
        }

        if (curHealth <= 0)
        {
            curHealth = 0;
            Death();
        }
    }

    void Death()
    {
        Debug.Log("Вы погибли");
        Destroy(Player);
    }

    public void TakeDamage(float damage)
    {
        curHealth -= damage;
    }

    public void TakeHeal()
    {
        curHealth += heal;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "HealItem") // Условие столкновения с хилкой
        {
            TakeHeal();
        }
    }
}