using UnityEngine;
using System.Collections;

public class Spell_cast : MonoBehaviour{
    public void casting(int spell_id,Transform Trig_Unit,Transform Target_Unit=null)
    {
        string Sp_idName = "Sp_" + spell_id.ToString();
        Transform CastSpell = this.transform.FindChild(Sp_idName);
        float spell_cd = CastSpell.GetComponent<Spell_bass>().spell_cd;
        if (this.GetComponent<Spell_Cd>().Hash_cd_rd(Trig_Unit,spell_id,spell_cd))
        {
            switch (spell_id)
            {
                case 101:                         //物理攻击
                    CastSpell.GetComponent<HandAttack>().Work(Trig_Unit);
                    break;
                case 102:                        //快速治疗
                    CastSpell.GetComponent<FlashHeal>().Work(Trig_Unit);
                    break;
                case 103:
                    CastSpell.GetComponent<Arrow_>().Work(Trig_Unit);
                    break;
                case 104:
                    CastSpell.GetComponent<Arrow_2>().Work(Trig_Unit);
                    break;
                case 105:
                    CastSpell.GetComponent<RocketEjector>().Work(Trig_Unit);
                    break;
                case 106:
                    CastSpell.GetComponent<FlameSpray>().Work(Trig_Unit);
                    break;
                default:
                    break;
            }
        }
        else
        {
            StartCoroutine(BufferTime(Trig_Unit, spell_id));
            string notice = CastSpell.GetComponent<Spell_bass>().spell_name + " 的冷却时间未恢复";
            Debug.Log(notice);
        }
    }
    IEnumerator BufferTime(Transform Trig_unit,int spell_id)
    {
        yield return new WaitForSeconds(0.7f);
        if (spell_id == 103||spell_id==104||spell_id==106)
        {
            Trig_unit.GetComponent<player>().Spell_status = 2;
        }
    }
}
