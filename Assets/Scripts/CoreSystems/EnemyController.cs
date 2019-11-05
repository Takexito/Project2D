using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IController 
{ 

    public AttackSystem attackSystem;
    public StatsSystem statsSystem;
    public EnemyMovement movement;
    public MonoBehaviour[] skills;
    public bool isAttack = false;

    public AttackSystem GetAttackSystem()
    {
        return attackSystem;
    }

    public StatsSystem GetStatsSystem()
    {
        return statsSystem;
    }

    void Update()
    {

    }

        private void UseSkill(int index)
    {
        if (skills[index] is ISkills) (skills[index] as ISkills).UseSkill();
    }


}
