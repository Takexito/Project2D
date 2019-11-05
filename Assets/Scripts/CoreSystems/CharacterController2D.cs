using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour, IController
{
    public AttackSystem attackSystem;
    public StatsSystem statsSystem;
    public CharacterMovement movement;
    public MonoBehaviour[] skills;

    public AttackSystem GetAttackSystem()
    {
        return attackSystem;
    }

    public StatsSystem GetStatsSystem()
    {
        return statsSystem;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !attackSystem.isAttack) attackSystem.StartCoroutine("Attack");
        if (Input.GetMouseButtonUp(0))attackSystem.StopCoroutine();
        if (Input.GetKeyDown(KeyCode.Space)) UseSkill(0);
        if (Input.GetKeyDown(KeyCode.Q)) UseSkill(1);
        if (Input.GetKeyDown(KeyCode.E)) UseSkill(2);
        if (Input.GetKeyDown(KeyCode.R)) UseSkill(3);
    }

    private void UseSkill(int index)
    {
        if (skills[index] is ISkills) (skills[index] as ISkills).UseSkill();
    }
}
