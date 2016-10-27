using UnityEngine;
using System.Collections;

public class Panshort : MonoBehaviour {
    public int Item_addr;
    public void Drop_es(string res)
    {
        this.transform.FindChild("P_" + res + "_s").GetComponent<Pan_short_signal>().isSet = false;
        this.transform.FindChild("P_" + res + "_s").GetComponent<Pan_short_signal>().change();
    }
}
