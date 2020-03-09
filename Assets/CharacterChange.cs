using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChange : MonoBehaviour
{
    CharacterController2D girlConroller;
    CharacterController2D robotConroller;
    public static bool isRobot = true;
    // Start is called before the first frame update
    void Start()
    {
        girlConroller = GameObject.FindGameObjectWithTag("Girl").GetComponent<CharacterController2D>();
        robotConroller = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();
        robotConroller.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isRobot)
            {
                isRobot = false;
                robotConroller.movement.Stop();
                robotConroller.SetActive(false);
                girlConroller.SetActive(true);
            }
            else
            {
                isRobot = true;
                girlConroller.movement.Stop();
                robotConroller.SetActive(true);
                girlConroller.SetActive(false);
            }
        }
    }

    public static string GetCurrentPlayerTag()
    {
        if (isRobot)
        {
            return "Player";
        }
        else return "Girl";
    }
}
