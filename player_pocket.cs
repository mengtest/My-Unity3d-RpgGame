using UnityEngine;
using System.Collections;

public class player_pocket : MonoBehaviour {
    private bool isCover;
    public Transform[] tItem_temp=new Transform[9];
    public Transform Model;
	void Start () {
        isCover = false;
	}
    bool findadr(Transform Item_t)
    {
        isCover = false;
        for(int k = 0; k < tItem_temp.Length; k++)
        {
            if (tItem_temp[k] != null)
            {
                if (tItem_temp[k].GetComponent<Self_class>().s_id == Item_t.GetComponent<Self_class>().s_id)
                {
                    tItem_temp[k].GetComponent<Self_class>().s_iCount++;
                    Destroy(Item_t.gameObject);
                    isCover = true;
                    return true;
                }
            }         
        }
        if (!isCover)
        {
            for (int k = 0; k < tItem_temp.Length; k++)
            {
                if (tItem_temp[k] == null)
                { 
                    tItem_temp[k] = Item_t;
                    return true;
                }
            }
            return false;
        }
        return false;
    }
    void Canvas_con()
    {
        GameObject.Find("Player_CAnvas").transform.FindChild("B_poc").gameObject.GetComponent<Pocket>().Update_canvas_con(tItem_temp);
    }
    public void Pick(Transform Item)
    {
        Transform I_temp = (Transform)Instantiate(Model, this.transform.position, this.transform.rotation);
        I_temp.parent = this.transform;
        I_temp.GetComponent<Self_class>().s_class = Item.GetComponent<Self_class>().s_class;
        I_temp.GetComponent<Self_class>().s_Icontent = Item.GetComponent<Self_class>().s_Icontent;
        I_temp.GetComponent<Self_class>().s_iType = Item.GetComponent<Self_class>().s_iType;
        I_temp.GetComponent<Self_class>().s_name = Item.GetComponent<Self_class>().s_name;
        I_temp.GetComponent<Self_class>().s_id = Item.GetComponent<Self_class>().s_id;
        I_temp.GetComponent<Self_class>().s_iCount = Item.GetComponent<Self_class>().s_iCount;
        Destroy(Item.gameObject);
        if (!findadr(I_temp))
        {
            Debug.Log("背包已满！");
        }
        Canvas_con();
    }
    public void drop(int Item_addr)
    {
        Destroy(tItem_temp[Item_addr].gameObject);
        tItem_temp[Item_addr] = null;
        Canvas_con();
    }
    public void use(int Item_addr)
    {
        int spell_id = this.transform.parent.FindChild("get_sName").GetComponent<get_sName>().Item_Spell(tItem_temp[Item_addr].GetComponent<Self_class>().s_id);
        this.transform.parent.FindChild("Spell").GetComponent<Spell_cast>().casting(spell_id, this.transform);
    }
}
