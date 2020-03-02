using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    GameObject parent;
    public float kickForce;

    // Start is called before the first frame update
    void Start()
    {
        parent = gameObject.transform.root.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            EnemyStatsSystem statsSystem = collision.GetComponent<EnemyStatsSystem>();
            statsSystem.TakeDamageAndStun(parent.GetComponent<CharacterStatsSystem>().GiveDamage(), 1f);
            collision.attachedRigidbody.AddForce(parent.transform.right * parent.transform.lossyScale.x * kickForce);
            Debug.Log("KICK!!!");
        }

    }
}
