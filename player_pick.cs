using UnityEngine;
using System.Collections;

public class player_pick : MonoBehaviour {
    public Transform tr;
    private int Item_id;
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Self_class>()!=null&& other.gameObject.GetComponent<Self_class>().s_class == "Hero")
        {
            Item_id = this.gameObject.GetComponent<Self_class>().s_id;
            other.gameObject.GetComponent<player_pocket>().Pick(Item_id);
            Destroy(this.gameObject);

        }
    }


}
