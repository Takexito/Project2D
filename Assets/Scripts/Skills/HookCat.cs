using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookCat : MonoBehaviour, ISkills
{
    public float range = 2f;
    public float dmg = 5f;
    private CharacterController2D playerControler;
    public LineRenderer line;

    public void UseSkill()
    {
        // Calculate Vectors
        Vector2 pos = playerControler.gameObject.transform.position;
        pos = new Vector2 (pos.x, pos.y);
        Vector2 dir = playerControler.movement.GetDirection();
        pos += dir;
        // Draw Line
        SetupLine(pos, pos + dir*range);
        Invoke("DisableLine", 0.5f);

        // Do RayCast
        RaycastHit2D hit2D = Physics2D.Raycast(pos, dir, range);
        if (hit2D)
        {
            GameObject target = hit2D.rigidbody.gameObject;
            if (target.tag == "Enemy")
            {
                target.GetComponent<EnemyStatsSystem>().TakeDamageAndStun(dmg);
                Debug.Log("Hook" + hit2D.distance);
                MoveCharacterToTarget(target.transform.position);
            }
            Debug.Log("Hook" + hit2D.rigidbody.tag);
        }

        
    }

    void MoveCharacterToTarget(Vector2 pos)
    {
        playerControler.movement.MoveToPoint(pos);
    }

    void DisableLine()
    {
        line.positionCount = 0;
    }

    void SetupLine(Vector2 start, Vector2 end)
    {
        line.sortingLayerName = "Ignore Raycast";
        line.sortingOrder = 5;
        line.positionCount = 2;
        line.SetPosition(0, start);
        line.SetPosition(1, end);
        line.startWidth = 1f;
        line.endWidth = 1f;
        line.useWorldSpace = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerControler = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();
        line = gameObject.AddComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
