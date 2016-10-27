using UnityEngine;
using System.Collections;

public class FlameSpray : MonoBehaviour {
    public Transform effect;
    public Transform spell_empty;
    public void Work(Transform Trig_Unit)
    {
        Transform s_effect;
        Transform s_sempty;
        Trig_Unit.GetComponent<Animator>().SetBool("isSpell_1", true);
        if (Trig_Unit.FindChild("Flame_Spary") == null)
        {
            s_effect = (Transform)Instantiate(effect, Trig_Unit.position + Trig_Unit.forward, Trig_Unit.rotation);
            s_sempty = (Transform)Instantiate(effect, Trig_Unit.position + Trig_Unit.forward, Trig_Unit.rotation);
            s_sempty.name = "Flame_Spray";
            s_sempty.parent = Trig_Unit;
            s_effect.name = "Flame_Spray_effct";
            s_effect.parent = s_sempty;
        }
        else
        {
            GameObject.Destroy(Trig_Unit.FindChild("Flame_Spary").gameObject);
        }
    }
}
