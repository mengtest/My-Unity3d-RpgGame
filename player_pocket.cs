using UnityEngine;
using System.Collections;

public class player_pocket : MonoBehaviour {
    private int pocket_adr;
    private int pick_Iid;
    private bool isCover;
    public int[] Item_arr=new int[9];
    public int[] Item_count = new int[9];
	void Start () {
        pocket_adr = 0;
        isCover = false;
	    for(int j = 0; j < 9; j++)
        {
            Item_arr[j] = Item_count[j] = 0;
        }
	}
    void findadr()
    {
        this.pocket_adr = 0;
        isCover = false;
        for(int k = 0; k < Item_arr.Length; k++)
        {
            if (Item_arr[k] == pick_Iid)
            {
                Item_count[k]++;
                isCover = true;
            }
        }
        if (!isCover)
        {
            while (Item_arr[this.pocket_adr] != 0)
            {
                this.pocket_adr++;
            }
            Item_arr[this.pocket_adr] = pick_Iid;
            Item_count[this.pocket_adr]++;
        }
    }
    void Canvas_con()
    {
        GameObject.Find("Player_CAnvas").transform.FindChild("B_poc").gameObject.GetComponent<Pocket>().Update_canvas(Item_arr, Item_count);
    }
    public void Pick(int Item_id)
    {
        pick_Iid = Item_id;
        findadr();
        Canvas_con();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
