using UnityEngine;
using System.Collections;

public class Bullent : MonoBehaviour {
    private float starttime;
    void Start()
    {
        starttime = Time.time;
        this.transform.position += Vector3.up * 2;
    }

    void Update()
    {
        //this.transform.position += transform.forward * Time.deltaTime;
        //if (Time.time - starttime > 10)
        //{
        //    Destroy(this.gameObject);
        //}
    }
}
