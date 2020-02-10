using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricProjectile : MonoBehaviour
{
    GameObject parent;

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
        EnemyStatsSystem statsSystem = collision.GetComponent<EnemyStatsSystem>();
        if (statsSystem != null)
            statsSystem.TakeDamage(parent.GetComponent<CharacterStatsSystem>().GiveDamage());
    }
}
