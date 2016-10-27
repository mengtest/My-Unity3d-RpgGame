using UnityEngine;
using System.Collections;

public class Bullent : MonoBehaviour {
    private float starttime;
    public Transform Trig_Unit;
    private string typename;
    void Start()
    {
        starttime = Time.time;
        this.transform.position += Vector3.up * 2;
        int len = this.transform.name.Length;
        typename=this.transform.name.Substring(0, len - 7);
    }

    void Update()
    {
        if (typename == "Bullet")
        {
            this.transform.position += transform.forward * 10 * Time.deltaTime;
            if (Time.time - starttime > 10)
            {
                Destroy(this.gameObject);
            }
        }
        else if(typename == "Bullet_2")
        {
            this.transform.position += transform.up * 20 * Time.deltaTime;
            if (Time.time - starttime > 5)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
