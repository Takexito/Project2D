using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) StartCoroutine(Attack());
    }

    public void change()
    {
        projectile.SetActive(!projectile.activeSelf);

    }

    IEnumerator Attack()
    {
        projectile.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        projectile.SetActive(false);
    }
}
