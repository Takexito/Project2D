using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private CharacterController2D charCont2d;
    public float dumping = 1.5f;
    public Vector2 offset = new Vector2(2f, 2f);
    private Transform player;

    void Start()
    {
        charCont2d = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();
        offset = new Vector2(Mathf.Abs(offset.x), Mathf.Abs(offset.y));
        player = GameObject.FindGameObjectWithTag(charCont2d.playableCharacterTagName).transform;
    }
    
    void Update()
    {
        //Debug.Log(charCont2d.playableCharacterTagName);
        player = GameObject.FindGameObjectWithTag(charCont2d.playableCharacterTagName).transform;
        
        if (player)
        {
            Vector3 currentPosition = Vector3.Lerp(transform.position, new Vector3(player.position.x, player.position.y, transform.position.z), dumping * Time.deltaTime);
            transform.position = currentPosition;
        }
    }
}
