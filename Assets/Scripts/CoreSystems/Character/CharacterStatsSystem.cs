using UnityEngine;

public class CharacterStatsSystem : MonoBehaviour
{
    // Start is called before the first frame update
    
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


    public bool isDie = false;

    void Start()
    {
        currHp = maxHp;
        Repeat();
    }

    void Repeat()
    {
        InvokeRepeating("RegenStm", 1f, 1f);  //1s delay, repeat every 1s
        InvokeRepeating("RegenHp", 1f, 1f);  //1s delay, repeat every 1s
    }

    void RegenHp()
    {
        if(currHp != maxHp) currHp += regenHp;
    }    
    void RegenStm()
    {
        if(currStm != maxStm && currStm < maxStm) currStm += regenStm;
        if (currStm > maxStm) currStm = maxStm;
    }

    // Update is called once per frame
    void Update()
    {
        ShouldDie();
    }

    public void Heal(float value)
    {
        currHp += value;
        if (currHp > 100) currHp = 100;
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

    public void SetAddDmg(float addDmg)
    {
        this.addDmg = addDmg;
    }

    public void TakeDamage(float dmg)
    {
        if (currHp - dmg <= 0) Die();
        else currHp -= dmg;
    }

    public float GiveDamage()
    {
        return dmg + addDmg;
    }
}
