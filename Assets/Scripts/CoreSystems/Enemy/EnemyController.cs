using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour 
{ 

    public EnemyAttackSystem attackSystem;
    public EnemyStatsSystem statsSystem;
    public EnemyMovement movement;

    public MonoBehaviour[] skills;

    [Header("Debug")]
    public bool isAttack = false;
    public bool stopMove = false;


    public void ChangeStunState(bool isStun)
    {
        statsSystem.isStun = isStun;
    }
    public EnemyAttackSystem GetAttackSystem()
    {
        return attackSystem;
    }

    public EnemyStatsSystem GetStatsSystem()
    {
        return statsSystem;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) UseSkill(0);
    }

        private void UseSkill(int index)
    {
        if (skills[index] is ISkills) (skills[index] as ISkills).UseSkill();
    }
}
