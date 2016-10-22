using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Scroll_life : MonoBehaviour {
    private float plife;
    private float slife;
	// Use this for initialization
	void Start () {
        plife = GameObject.Find("player").gameObject.GetComponent<Self_class>().getLife();
        slife= GameObject.Find("player").gameObject.GetComponent<Self_class>().s_life;
    }
	
	// Update is called once per frame
	void Update () {
        plife = GameObject.Find("player").gameObject.GetComponent<Self_class>().getLife();
        slife = GameObject.Find("player").gameObject.GetComponent<Self_class>().s_life;
        this.gameObject.GetComponent<Scrollbar>().size = plife / slife;
        this.transform.Find("T_pl").GetComponent<Text>().text = ((int)plife).ToString() + "/" + ((int)slife).ToString();
	}
}
