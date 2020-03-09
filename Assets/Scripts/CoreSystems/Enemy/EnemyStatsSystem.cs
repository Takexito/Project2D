using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatsSystem : MonoBehaviour
{

    private EnemyController controller;
    private CharacterAttackSystem attackSystem;

    // HP
    [Header("Максимальное здоровье")]
    public float maxHp = 100f;
    [Header("Текущее здоровье")]
    public float currHp;
    public float regenHp = 1f;

    // Dmg
    [Header("Наносимый урон")]
    public float dmg = 25f;
    public float addDmg;
    //Stamina
    public float maxStm = 25f;
    public float currStm = 0f;
    public float regenStm = 5f;

    // Status
    public bool isStun = false;
    public bool isDie = false;

    void Start()
    {
        controller = gameObject.GetComponent<EnemyController>();
        attackSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterAttackSystem>();
        currHp = maxHp;
        Repeat();
    }

    void Update()
    {
        ShouldDie();
    }

    void Repeat()
    {
        InvokeRepeating("RegenStm", 1f, 1f);  //1s delay, repeat every 1s
        InvokeRepeating("RegenHp", 1f, 1f);  //1s delay, repeat every 1s

    }

    // Hp & Stamina
    void RegenHp()
    {
        if (currHp != maxHp) currHp += regenHp;
    }
    void RegenStm()
    {
        if (currStm != maxStm) currStm += regenStm;
    }

    public void Heal(float value)
    {
        currHp += value;
        if (currHp > 100) currHp = 100;
    }


    // Status
    IEnumerator Stun(float duration)
    {
        controller.movement.Stop(true);
        isStun = true;
        yield return new WaitForSeconds(duration);
        isStun = false;
        controller.movement.Stop(false);

    }

    public void ShouldDie()
    {
        if (currHp <= 0) Die();
    }

    public void Die()
    {
        currHp = 0;
        isDie = true;
        Destroy(this.gameObject);
    }

    // Damage
    public void SetAddDmg(float addDmg)
    {
        this.addDmg = addDmg;
    }

    public void TakeDamage(float dmg)
    {
        if (currHp - dmg <= 0) Die();
        else
        {
            attackSystem.attackCheck = true;
            currHp -= dmg;
        }
    }

    public void TakeDamageAndStun(float dmg, float time = 0.5f)
    {
        TakeDamage(dmg);
        StartCoroutine(Stun(time));
    }

    public float GiveDamage()
    {
        return dmg + addDmg;
    }

}
