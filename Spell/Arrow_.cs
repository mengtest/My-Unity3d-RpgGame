using UnityEngine;
using System.Collections;

public class Arrow_ : MonoBehaviour {
    public Transform effect;
    public Transform Model;
    public void Work(Transform Trig_Unit)
    {
        Transform s_effect;
        Transform bullet;
        Trig_Unit.GetComponent<Animator>().SetBool("isSpell_1", true);
        bullet = (Transform)Instantiate(Model, Trig_Unit.position, Trig_Unit.rotation);
        bullet.GetComponent<Bullent>().Trig_Unit = Trig_Unit;
        Quaternion ro = new Quaternion(0,1,0,0);
        s_effect = (Transform)Instantiate(effect, bullet.position, bullet.rotation*ro);
        s_effect.parent = bullet;
    }
}
