using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IController 
{ 

    public AttackSystem attackSystem;
    public StatsSystem statsSystem;
    public EnemyMovement movement;
    public MonoBehaviour[] skills;
    [Header("Debug")]
    public bool isAttack = false;
    public bool stopMove = false;
    public bool isStun = false;

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
       // movement.isStop = stopMove;
        movement.isStop = isStun;
        attackSystem.isStun = isStun;
        if (Input.GetKeyDown(KeyCode.Z)) UseSkill(0);
    }

        private void UseSkill(int index)
    {
        if (skills[index] is ISkills) (skills[index] as ISkills).UseSkill();
    }

    IEnumerator Stun()
    {
        isStun = true;
        yield return new WaitForSeconds(0.7f); 
        isStun = false;
    }
}
