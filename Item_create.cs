using UnityEngine;
using System.Collections;

public class Item_create : MonoBehaviour {

    // Use this for initialization
    public Transform Item;
    private Vector3 Item_pos;
    private float cr_time;
    private Transform clone;
	void Start () {
        cr_time=0;
	}
    void Item_pos_c()
    {
        float pos_x = Random.Range(2, 55);
        float pos_z = Random.Range(2, 55);
        float pos_y = Terrain.activeTerrain.SampleHeight(new Vector3(pos_x, 1, pos_z))+2;
        Item_pos = new Vector3(pos_x, pos_y, pos_z);
    }
	// Update is called once per frame
	void Update () {
        
    }
    void FixedUpdate()            //0.02 秒一帧
    {
        if (Time.time - cr_time > 4)
        {
            Item_pos_c();
            int rnd = ((int)Random.Range(0, 4) ) + 20001;
            clone =(Transform)Instantiate(Item, Item_pos, Quaternion.identity);
            clone.tag = "Item";
            clone.parent = this.transform;
            clone.gameObject.GetComponent<Self_class>().s_id = rnd;
            cr_time = Time.time;
        }
    }
}
