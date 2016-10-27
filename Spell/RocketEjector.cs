using UnityEngine;
using System.Collections;

public class RocketEjector : MonoBehaviour {
    public Transform effect;
    public void Work(Transform Trig_Unit)
    {
        Transform s_effect;
        Trig_Unit.GetComponent<Animator>().SetBool("isSpell_1", true);
        s_effect = (Transform)Instantiate(effect, Trig_Unit.position-2*Trig_Unit.forward, Trig_Unit.rotation);
        s_effect.name = "ejector";
        s_effect.parent = Trig_Unit;
        Trig_Unit.GetComponent<Self_class>().s_speed = 20;
        Trig_Unit.GetComponent<player>().JumpSpeed = 90;
        Trig_Unit.GetComponent<player>().Move();
    }
}
