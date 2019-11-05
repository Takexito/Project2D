using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpTextBridge : MonoBehaviour
{
    public Text text;
    StatsSystem stats;
    // Start is called before the first frame update
    void Start()
    {
       stats = GameObject.FindGameObjectWithTag("Player").GetComponent<IController>().GetStatsSystem();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = stats.currHp + "/" + stats.maxHp;
    }
}
