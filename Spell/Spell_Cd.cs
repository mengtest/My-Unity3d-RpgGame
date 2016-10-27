using UnityEngine;
using System.Collections;

public class Spell_Cd : MonoBehaviour {
    private Hashtable Hash_cd=new Hashtable();
    public void Hash_cd_wr(Transform Trig_unit,int cast_id)
    {
        int unit_id = Trig_unit.GetComponent<Self_class>().s_id;
        string Hash_key = unit_id.ToString() + cast_id.ToString();
        if (Hash_cd.Contains(Hash_key))
        {
            Hash_cd[Hash_key] = Time.time;
        }
        else
        {
            Hash_cd.Add(Hash_key, Time.time);
        }
    }
    public bool Hash_cd_rd(Transform Trig_unit,int cast_id,float cd)
    {
        int unit_id = Trig_unit.GetComponent<Self_class>().s_id;
        string Hash_key = unit_id.ToString() + cast_id.ToString();
        if (Hash_cd.Contains(Hash_key))
        {
           
            if (Time.time - (float)Hash_cd[Hash_key] > cd)
            {
                this.Hash_cd_wr(Trig_unit, cast_id);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            this.Hash_cd_wr(Trig_unit, cast_id);
            return true;
        }
    }
}
