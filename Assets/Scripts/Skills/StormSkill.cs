using System.Collections;
using UnityEngine;

public class StormSkill : MonoBehaviour, ISkills
{
    public float coolDown = 2;
    public float coolDownEnd = 0;

    GameObject parent;
    public void Start()
    {
        parent = Single.Instance.CharacterController2D.gameObject;
    }
    public void UseSkill()
    {
        if (Time.time > coolDownEnd)
        {
            coolDownEnd = Time.time + coolDown;
            StartCoroutine(StormSkillCor());
        }
    }

    IEnumerator StormSkillCor()
    {
        //CharacterAttackSystem attack = parent.GetComponent<IController>().GetAttackSystem();
        //float end = Time.time + 3;
        //attack.Change();
        //while (Time.time < end)
        //{
        //    parent.transform.Rotate(Vector3.forward * -60f);
            yield return new WaitForSeconds(0.1f); // Задержка выполнения следующего шага
        //}
        //parent.transform.rotation = new Quaternion(0, 0, 0, 0);
        //attack.Change();
    }

}
