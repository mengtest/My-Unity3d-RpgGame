using UnityEngine;
using System.Collections;

public class HandAttack : MonoBehaviour
{
    public void Work(Transform Trig_Unit)
    {
        int m = 0;
        Transform[] Target = new Transform[10];
        Trig_Unit.GetComponent<Animator>().SetBool("isAttack",true);
        StartCoroutine(this.Work_on(Target, m,Trig_Unit));
    }
    private IEnumerator Work_on(Transform []Target,int m,Transform Trig_Unit)
    {
        yield return new WaitForSeconds(0.7f);
        Vector3 Trig_point = Trig_Unit.position;
        RaycastHit hit;
        bool isCover = false;
        for (int j = 0; j < 3; j++)
        {
            for (int k = 0; k < 3; k++)
            {
                Trig_point = Trig_Unit.position + k * Trig_Unit.right + j * Trig_Unit.up - Trig_Unit.right - 0.2f * Trig_Unit.up;
                //Instantiate(Bullent, Trig_point, Trig_Unit.rotation);
                if (Physics.Linecast(Trig_point, Trig_point + Trig_Unit.forward * 2, out hit))
                {
                    isCover = false;
                    foreach (Transform ta in Target)
                    {
                        if (ta == hit.collider.transform || hit.collider.transform == Trig_Unit)
                        {
                            isCover = true;
                            break;
                        }
                    }
                    if (!isCover)
                    {
                        Target[m] = hit.collider.transform;
                        m++;
                    }

                }
            }
        }
        for (int n = 0; n < m; n++)
        {
            if (Target[n].GetComponent<Self_class>().s_class == "Hero"&& Target[n].GetComponent<Self_class>().isLife==true)
            {
                Debug.Log(Target[n].name + " attacked");
                Target[n].GetComponent<Self_class>().injured(Trig_Unit.GetComponent<Self_class>().s_AttackValue);
            }
        }
    }
}
