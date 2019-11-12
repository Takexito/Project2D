using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMoSkill : MonoBehaviour, ISkills
{
    public float coolDown = 2;
    public float coolDownEnd = 0;

    private bool isSlow = false;
    public void UseSkill()
    {
        if (Time.time > coolDownEnd)
        {
            coolDownEnd = Time.time + coolDown;
            if (!isSlow)
            {
                isSlow = true;
                Time.timeScale = 0.5f;
            }
            else
            {
                isSlow = true;
                Time.timeScale = 1f;
            }
        }
    }
}
