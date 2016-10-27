using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Pocket_Dashboard : MonoBehaviour
{
    private string dash_Item;
    private int dash_addr;
    private string dash_content;
    private Transform canvas_player;
	void Start () {
        this.gameObject.SetActive(false);
        dash_addr = 1;
        canvas_player = GameObject.Find("Hero").transform.FindChild("player");
	}
    public void work(int addr,Transform Item)
    {
        dash_addr = addr+1;
        dash_Item = Item.GetComponent<Self_class>().s_name;
        dash_content = Item.GetComponent<Self_class>().s_Icontent;
        this.transform.FindChild("Issue").GetComponent<Text>().text = "物品栏" + dash_addr.ToString() + " :" + dash_Item;
        this.transform.FindChild("Content").GetComponent<Text>().text = dash_content;
    }
    public void drop()
    {
        canvas_player.GetComponent<player_pocket>().drop(dash_addr-1);
        string res = "Start";
        while (res!= "Empty"){
            res = canvas_player.GetComponent<play_joystick>().query_i((dash_addr - 1));
            Debug.Log(res);
            if (res == "Empty")
            {
                break;
            }
            else
            {
                this.transform.parent.FindChild("Pan_shortcut").GetComponent<Panshort>().Drop_es(res);
                canvas_player.GetComponent<play_joystick>().remove(res);
            }
        }
        this.close();
    }
    public void close()
    {
        this.gameObject.SetActive(false);
    }
    public void shortcut()
    {
        this.gameObject.SetActive(false);
        this.transform.parent.FindChild("Pan_shortcut").gameObject.SetActive(true);
        this.transform.parent.FindChild("Pan_shortcut").GetComponent<Panshort>().Item_addr = dash_addr;
    }
    public void use()
    {
        canvas_player.GetComponent<player_pocket>().use(dash_addr - 1);
        //canvas_player.parent.FindChild("Spell").GetComponent<Spell_cast>().casting(this.transform.FindChild("get_sName").GetComponent<get_sName>().Item_Spell(Item_id), canvas_player);
    }
}
