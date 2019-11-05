using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMoSkill : MonoBehaviour, ISkills
{
    private bool isSlow = false;
    public void UseSkill()
    {
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
