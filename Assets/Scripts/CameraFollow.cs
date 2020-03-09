using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject robot;
    private GameObject girl;
    public float dumping = 1.5f;
    public Vector2 offset = new Vector2(2f, 2f);
    private Transform player;

    void Start()
    {
        robot = GameObject.FindGameObjectWithTag("Player");
        girl = GameObject.FindGameObjectWithTag("Girl");
        offset = new Vector2(Mathf.Abs(offset.x), Mathf.Abs(offset.y));
    }
    
    void Update()
    {
        //Debug.Log(charCont2d.playableCharacterTagName);

        if (CharacterChange.isRobot) player = robot.transform;
        else player = girl.transform;

        Vector3 currentPosition = Vector3.Lerp(transform.position, new Vector3(player.position.x, player.position.y, transform.position.z), dumping * Time.deltaTime);
        transform.position = currentPosition;
    }
}
