using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
public class OnButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{  
    private float delay = 0.05f;
    private bool isDown;
    private float downTIme;
    public string Deal;
    public string Status;
    void Start()
    {
        Deal = "KeyFree";
        Status = "KeyFree";
        downTIme = 0;
        isDown = false;
    }
    void Update()
    {
        if (isDown && Time.time - downTIme > delay)
        {
            Status = "KeyUp";
            //downTIme = Time.time;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Deal = "KeyDown";
        Status = "KeyDown";
        downTIme = Time.time;
        isDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Deal = "KeyUp";
        Status = "KeyFree";
        isDown = false;
    }
 
    public void OnPointerExit(PointerEventData eventData)
    {
        Deal = "KeyFree";
        Status = "KeyFree";
        isDown = false;
    }
}
