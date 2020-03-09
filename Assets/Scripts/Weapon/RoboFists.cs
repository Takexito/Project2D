using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboFists : MonoBehaviour
{
    GameObject parent;
    public Transform popupDamgage;

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
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("ATTACK");
            EnemyStatsSystem statsSystem = collision.GetComponentInParent<EnemyStatsSystem>();
            int dmg = (int) parent.GetComponent<CharacterStatsSystem>().GiveDamage();
            statsSystem.TakeDamage(dmg);
            DamagePopup.Create(statsSystem.transform.position, dmg, false, popupDamgage);
        }

    }
}
