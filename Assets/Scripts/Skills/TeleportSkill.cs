using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSkill : MonoBehaviour, ISkills
{
    public Transform target;
    public float spaceToTarget = 5f;
    public GameObject parent;
    public float coolDown = 2;
    public float coolDownEnd = 0;


    void Start()
    {
        parent = Single.Instance.CharacterController2D.gameObject;
        target = Single.Instance.CharacterController2D.target.transform;
    }

    // Может ли объект телепортироватся к цели
    // Заготовка для логики на уровне (тп к стенам)
    bool canTeleport() 
    {
        return true;
    }


    // Получаем обратный вектор направления цели
    Vector3 getBackVector()
    {
        float x = 1;
        float y = 1;
        float z = 0;

        if (target.position.x <= parent.transform.position.x) x = -1;
        if (target.position.y <= parent.transform.position.y) y = -1;

        return new Vector3(x,y,z);
    }

    public void UseSkill()
    {
        if (Time.time > coolDownEnd)
        {
            coolDownEnd = Time.time + coolDown;
            Vector2 pos = target.position + Vector3.Scale(new Vector2(spaceToTarget, 0f), getBackVector());
            (parent.GetComponent<IController>() as EnemyController).ChangeStunState(true);
            (parent.GetComponent<IController>() as EnemyController).ChangeStunState(false);
            Debug.Log("X = " + pos.x + " Y = " + pos.y);
            parent.transform.position = pos;
        }
    }
}
