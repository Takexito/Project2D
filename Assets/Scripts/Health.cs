using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("Игрок")]
    public GameObject Player;

    [Header("Текущее здоровье")]
    public float curHealth;

    [Header("Максимальное здоровье")]
    public float maxHealth;

   /* [Header("HealthBar")]
    public GameObject Bar;

    [Header("HP")]
    public Text healthText; */

    void Update()
    {
       /* Bar.transform.localScale = new Vector2(curHealth / maxHealth, 1); // Сдвиг полоски HealtBar
        healthText.text = curHealth.ToString("0"); // Изменение числа HP */

        if (curHealth >= maxHealth)
        {
            curHealth = maxHealth;
        }

        if (curHealth <= 0)
        {
            curHealth = 0;
            Death();
        }
    }

    void Death()
    {
        Destroy(Player);
    }

    /*
    public void TakeDamage(float damage)
    {
        curHealth -= damage;
    }
    */
}