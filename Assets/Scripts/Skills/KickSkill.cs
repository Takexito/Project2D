using System.Collections;
using UnityEngine;

public class KickSkill : MonoBehaviour, ISkills
{
    public float coolDown = 2;
    public float coolDownEnd = 0;
    public float kickForce = 1f;
    public bool isKick = false;


    CharacterController2D parent;
    public void Start()
    {
        
    }
    public void UseSkill()
    {

        parent = GameObject.FindGameObjectWithTag(CharacterChange.GetCurrentPlayerTag()).GetComponent<CharacterController2D>();
        if (Time.time > coolDownEnd)
        {
            Debug.Log("USE");
            
            coolDownEnd = Time.time + coolDown;
            isKick = true;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && isKick)
        {
            isKick = false;
            EnemyStatsSystem statsSystem = collision.GetComponentInParent<EnemyStatsSystem>();
            statsSystem.TakeDamageAndStun(parent.GetComponent<CharacterStatsSystem>().GiveDamage(), 0.25f);
            collision.attachedRigidbody.AddForce(parent.movement.lastDirectionVector2 * parent.transform.lossyScale.x * kickForce);
            Debug.Log("KICK!!!");

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.tag == "Enemy" && isKick)
        {
            isKick = false;
            EnemyStatsSystem statsSystem = collision.GetComponentInParent<EnemyStatsSystem>();
            statsSystem.TakeDamageAndStun(parent.GetComponent<CharacterStatsSystem>().GiveDamage(), 0.25f);
            collision.attachedRigidbody.AddForce(parent.movement.lastDirectionVector2 * kickForce);
            Debug.Log("KICK!!!");
            
        }

    }

}
