using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Pocket_Dashboard : MonoBehaviour
{
    private string dash_Item;
    private int dash_id;
    private int dash_addr;
    private string dash_content;
	void Start () {
        this.gameObject.SetActive(false);
        dash_addr = 1;
	}
    public void work(int addr,int sid)
    {
        dash_addr = addr+1;
        dash_id = sid;
        dash_Item = this.transform.FindChild("get_sName").GetComponent<get_sName>().Item_name(sid);
        dash_content = this.transform.FindChild("get_sName").GetComponent<get_sName>().Item_content(sid);
        this.transform.FindChild("Issue").GetComponent<Text>().text = "物品栏" + dash_addr.ToString() + " :" + dash_Item;
        this.transform.FindChild("Content").GetComponent<Text>().text = dash_content;
    }
    public void drop()
    {
        GameObject.Find("player").GetComponent<player_pocket>().drop(dash_id, dash_addr-1);
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
    }

}
