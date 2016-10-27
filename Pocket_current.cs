using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class Pocket_current :MonoBehaviour,IPointerDownHandler
{
    private bool isEmpty;
    private int addr;
    private Transform Item;
	// Use this for initialization
    int getaddr(string str)
    {
        int addr = str[str.Length - 1] - 49;
        return addr;
    }
	void Start () {
        isEmpty = true;
        addr = getaddr(this.gameObject.name);
	}
	
	// Update is called once per frame
	public void OnPointerDown(PointerEventData eventData)
    {
        isEmpty = this.transform.parent.parent.FindChild("B_poc").GetComponent<Pocket>().Empty_check(addr);
        Item = this.transform.parent.parent.FindChild("B_poc").GetComponent<Pocket>().Item_get(addr);
        if (!isEmpty)
        {
            this.transform.parent.FindChild("Pocket_dashboard").gameObject.SetActive(true);
            this.transform.parent.FindChild("Pocket_dashboard").GetComponent<Pocket_Dashboard>().work(addr,Item);
        }
    }
}
