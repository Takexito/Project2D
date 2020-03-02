using System.Collections;
using UnityEngine;

public class KickSkill : MonoBehaviour, ISkills
{
    public float coolDown = 2;
    public float coolDownEnd = 0;

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

}
