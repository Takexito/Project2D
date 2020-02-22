using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboTextBridge : MonoBehaviour
{
    public Text text;
    CharacterAttackSystem attack;

    private void Start()
    {
        attack = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterAttackSystem>();
    }

    private void Update()
    {
        text.text = "Combo: " + attack.comboCounter;
        if (Time.time - attack.startCombo < attack.timeComboBreak)
        {
            text.color = Color.red;
        }
        else
        {
            text.color = Color.clear;
        }
    }
}
