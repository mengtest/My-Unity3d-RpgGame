using UnityEngine;
using System.Collections;

public class player_life : MonoBehaviour {

    public float p_life;
    public Animator ani;
	void Start () {
        p_life = this.gameObject.GetComponent<Self_class>().s_life;
	}
	
	void Update () {
        //if(p_life>0)
        //    p_life -= 2f;
        if (p_life < 1)
           this.gameObject.GetComponent<player>().isLife = false;

    }
}
