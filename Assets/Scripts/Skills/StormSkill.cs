using System.Collections;
using UnityEngine;

public class StormSkill : MonoBehaviour, ISkills
{
    GameObject parent;
    public void Start()
    {
        parent = gameObject.transform.root.gameObject;
    }
    public void UseSkill()
    {
        StartCoroutine(StormSkillCor());
    }

    IEnumerator StormSkillCor()
    {
        AttackSystem attack = parent.GetComponent<IController>().GetAttackSystem();
            //GameObject.FindGameObjectsWithTag("Player")[0]
            //.GetComponent<CharacterController2D>().attackSystem;
        float end = Time.time + 3;
        attack.Change();
        while (Time.time < end)
        {
            //GameObject.FindGameObjectsWithTag("Player")[0].transform.Rotate(Vector3.forward * 60f);
            parent.transform.Rotate(Vector3.forward * 60f);
            yield return new WaitForSeconds(0.1f); // Задержка выполнения следующего шага
            
        }
        parent.transform.rotation = new Quaternion(0, 0, 0, 0);
        attack.Change();
    }

}
