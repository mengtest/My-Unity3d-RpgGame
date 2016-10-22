using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;

public class Pocket : MonoBehaviour {

    // Use this for initialization
    public Sprite[] Item_image;
    public Sprite Empty_image;
    private int[] U_Item_id=new int[20];
    private int[] U_Item_count=new int[20];
    private bool isUpdate;
    private bool isOpen;
    private float delay;
    private float pretime;
	void Start () {
        delay = 0.5f;
        for (int i = 1; i < 10; i++)
        {
            this.transform.parent.Find("Pocket").FindChild("tP_" + i.ToString()).gameObject.SetActive(false);
        }
        this.transform.parent.Find("Pocket").gameObject.SetActive(false);
        this.transform.parent.Find("Pocket").FindChild("Pan_shortcut").gameObject.SetActive(false);
        isOpen = false;
        pretime = 0;
        isUpdate = false;
	}
    private void Update_canvas()
    {
        if (isUpdate)                               
        {
            for (int j = 0; j < U_Item_count.Length; j++)
            {
                if (U_Item_count[j] == 0 || U_Item_id[j] == 0)
                {
                    this.transform.parent.Find("Pocket").FindChild("P_" + (j + 1).ToString()).GetComponent<Image>().sprite = Empty_image;
                    this.transform.parent.Find("Pocket").FindChild("tP_" + (j + 1).ToString()).GetComponent<Text>().text = " ";
                    this.transform.parent.Find("Pocket").FindChild("tP_" + (j + 1).ToString()).gameObject.SetActive(false);
                }
                if (U_Item_count[j] > 0)
                {
                    this.transform.parent.Find("Pocket").FindChild("tP_" + (j+1).ToString()).gameObject.SetActive(true);
                    this.transform.parent.Find("Pocket").FindChild("tP_" + (j+1).ToString()).GetComponent<Text>().text = U_Item_count[j].ToString();
                }
                if (U_Item_id[j] - 20001 > -1)
                {
                    this.transform.parent.Find("Pocket").FindChild("P_" + (j + 1).ToString()).GetComponent<Image>().sprite = Item_image[U_Item_id[j] - 20001];
                }
            }
            isUpdate = false;
        }
    }
    public void Update_canvas(int[] id,int[] adr)
    {
        isUpdate = true;        
        U_Item_id = (int[])id.Clone();
        U_Item_count = (int[])adr.Clone();
        if (isOpen)                                                 //更新背包，背包打开时获得物品
        {
            this.transform.parent.Find("Pocket").gameObject.SetActive(true);
            this.Update_canvas();
        }
    }
    public bool Empty_check(int addr)
    {
        return U_Item_count[addr] > 0 ? false : true;
    }
    public int Itemid_get(int addr)
    {
        return U_Item_id[addr];
    }
    void Poc_control()
    {
        if (this.gameObject.GetComponent<OnButtonPressed>().Deal == "KeyDown" && Time.time - pretime > delay)
        {
            pretime = Time.time;
            isOpen = (isOpen == false ? true : false);
            if (isOpen)
            {                                                                   //更新背包，背包关闭时获得物品
                this.transform.parent.Find("Pocket").gameObject.SetActive(true);
                this.Update_canvas();
            }
            else
            {
                this.transform.parent.Find("Pocket").gameObject.SetActive(false);
                this.transform.parent.FindChild("Pocket").FindChild("Pan_shortcut").gameObject.SetActive(false);
            }

        }

    }
    void Update()
    {
        Poc_control();
    }
}
