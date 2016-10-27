using UnityEngine;
using System.Collections;

public class Arrow_2 : MonoBehaviour
{
    public Transform effect;
    public Transform Model;
    public void Work(Transform Trig_Unit)
    {
        Transform s_effect;
        Transform bullet;
        Trig_Unit.GetComponent<Animator>().SetBool("isSpell_1", true);
        Quaternion co = new Quaternion(Mathf.Sqrt(2)/2, 0, 0, Mathf.Sqrt(2) / 2);
        bullet = (Transform)Instantiate(Model, Trig_Unit.position, Trig_Unit.rotation*co);
        bullet.GetComponent<Bullent>().Trig_Unit = Trig_Unit;
        s_effect = (Transform)Instantiate(effect, bullet.position, Trig_Unit.rotation);
        s_effect.parent = bullet;
    }
}

