using UnityEngine;
using System.Collections;

public class play_joystick : MonoBehaviour {
    private Hashtable Hash_dash = new Hashtable();
    public void work(string result)
    {
        if (Hash_dash.Contains(result))
        {
            this.transform.GetComponent<player_pocket>().use((int)Hash_dash[result]);
        }
        else
        {
            Debug.Log("该快捷键无绑定物品");
        }
    }
    public void set(string res,int Item_addr)
    {
        if(Hash_dash.Contains(res)){
            Hash_dash[res] = Item_addr;
        }
        else
        {
            Hash_dash.Add(res, (object)Item_addr);
        }
    }
    public bool query(string res)
    {
        return Hash_dash.Contains(res);
    }
    public string query_i(int Addr)
    {
        foreach(DictionaryEntry de in Hash_dash)
        {
            if ((int)de.Value == Addr)
            {
                return (string)de.Key;
            }
        }
        return "Empty";
    }
    public void remove(string res)
    {
        Hash_dash.Remove(res);
    }
}
