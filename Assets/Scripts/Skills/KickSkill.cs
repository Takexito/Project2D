using System.Collections;
using UnityEngine;

public class KickSkill : MonoBehaviour, ISkills
{
    public float coolDown = 2;
    public float coolDownEnd = 0;
    public float kickForce;


    CharacterController2D parent;
    public void Start()
    {
        parent = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();
    }
    public void UseSkill()
    {
        if (Time.time > coolDownEnd)
        {
            coolDownEnd = Time.time + coolDown;
            CharacterAttackSystem attack = parent.attackSystem;

            attack.AddAtackToQueue(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyStatsSystem statsSystem = collision.GetComponent<EnemyStatsSystem>();
            statsSystem.TakeDamageAndStun(parent.GetComponent<CharacterStatsSystem>().GiveDamage(), 1f);
            collision.attachedRigidbody.AddForce(parent.transform.right * parent.transform.lossyScale.x * kickForce);
            Debug.Log("KICK!!!");
        }

    }

}
