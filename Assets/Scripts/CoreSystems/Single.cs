using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single : MonoBehaviour
{
    private static Single _instance;

    public static Single Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
        getData();
    }

    public CharacterController2D CharacterController2D;

    private void getData()
    {
        CharacterController2D = GameObject.FindGameObjectWithTag("Player").GetComponent("CharacterController2D") as CharacterController2D;
    }
}
