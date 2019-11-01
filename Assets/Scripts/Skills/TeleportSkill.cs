using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSkill : MonoBehaviour
{
    public Transform target;
    public float spaceToTarget = 5f;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)) teleport();
    }

    // Может ли объект телепортироватся к цели
    // Заготовка для логики на уровне (тп к стенам)
    bool canTeleport() 
    {
        return true;
    }

    void teleport()
    {
        Vector3 pos = target.position + Vector3.Scale(new Vector3(spaceToTarget, 0f), getBackVector());
        
        Debug.Log(getBackVector());
        rb2d.MovePosition(pos);
    }

    // Получаем обратный вектор направления цели
    Vector3 getBackVector()
    {
        float x = 1;
        float y = 1;
        float z = 0;

        if (target.position.x <= transform.position.x) x = -1;
        if (target.position.y <= transform.position.y) y = -1;

        return new Vector3(x,y,z);
    }
}
