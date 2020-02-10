using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour, IController
{
    public CharacterAttackSystem attackSystem;
    public CharacterStatsSystem statsSystem;
    public CharacterMovement movement;
    public MonoBehaviour[] skills;
    public GameObject target;
    public Animator animator;
    private bool isStun = false;

    public CharacterAttackSystem GetAttackSystem()
    {
        return attackSystem;
    }

    public CharacterStatsSystem GetStatsSystem()
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
        if (Input.GetMouseButtonDown(0)) attackSystem.AddAtackToQueue();
        if (Input.GetKeyDown(KeyCode.Space)) UseSkill(0);
        if (Input.GetKeyDown(KeyCode.Q)) UseSkill(1);
        if (Input.GetKeyDown(KeyCode.E)) UseSkill(2);
        if (Input.GetKeyDown(KeyCode.R)) UseSkill(3);
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

    public void ChangeStunState(bool isStun)
    {
        this.isStun = isStun;
    }
}
