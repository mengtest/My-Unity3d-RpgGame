using UnityEngine;
using System.Collections;

public class FlashHeal : MonoBehaviour {
    public Transform effect;
    public void Work(Transform Trig_Unit)
    {
        Transform s_effect;
        s_effect=(Transform)Instantiate(effect, Trig_Unit.position, Trig_Unit.rotation);
        s_effect.parent = Trig_Unit;
        StartCoroutine(Work_on(Trig_Unit, s_effect));
    }
    private IEnumerator Work_on(Transform Trig_Unit, Transform s_effect)
    {
        yield return new WaitForSeconds(1f);
        Trig_Unit.GetComponent<Self_class>().Heal(100);
        yield return new WaitForSeconds(2f);
        GameObject.Destroy(s_effect.gameObject);
        Trig_Unit.GetComponent<player>().isCastingComplete = true;
    }
}
