using UnityEngine;
using System.Collections;

public class player_pick : MonoBehaviour {
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Self_class>()!=null&& other.gameObject.GetComponent<Self_class>().s_class == "Hero")
        {
            Transform Item = this.transform;
            other.gameObject.GetComponent<player_pocket>().Pick(Item);
        }
    }
}
