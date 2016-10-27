using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Joystick : MonoBehaviour ,IPointerDownHandler,IPointerEnterHandler,IPointerExitHandler,IPointerUpHandler,IDragHandler
{
    public Transform cplayer;
    private float u_x, u_y;
    private float shift;
    private float angle;
    private Vector3 u_pos;
    private bool isWork;
    public string result;
    void Start()
    {
        result = "empty";
        angle = 0;
        shift = 0;
        u_pos=this.transform.position;
        isWork = false; 
    }
    public void OnPointerDown(PointerEventData eventdata)
    {
        isWork = true;
    }
    public void OnPointerUp(PointerEventData eventdata)
    {
        isWork = false;
        this.transform.position = u_pos;
    }
    public void OnPointerEnter(PointerEventData eventdata)
    {
        isWork = true;
    }
    public void OnPointerExit(PointerEventData eventdata)
    {
        isWork = false;
    }
    public void OnDrag(PointerEventData eventdata)
    {
        if (isWork)
        {
            u_x = eventdata.position.x - u_pos.x;
            u_y = eventdata.position.y - u_pos.y;
            angle = Mathf.Atan2(u_y, u_x);
            shift = Mathf.Sqrt(u_x * u_x + u_y * u_y);
            shift = (shift > 50 ? 50 : shift);
            this.transform.position=new Vector3(u_pos.x+shift*Mathf.Cos(angle), u_pos.y+shift * Mathf.Sin(angle), 0);
            if (shift == 50)
            {
                if (angle > Mathf.PI / 4 && angle <= Mathf.PI * 3 / 4)
                {
                    result = "Up";
                }
                else if (angle > Mathf.PI * 3 / 4 || angle <= Mathf.PI * -3 / 4)
                {
                    result = "Left";
                }
                else if (angle < Mathf.PI *-1/ 4 && angle >= Mathf.PI * -3 / 4)
                {
                    result = "Down";
                }
                else
                {
                    result = "Right";
                }
                cplayer.GetComponent<play_joystick>().work(result);
                shift = 0;
                this.transform.position = new Vector3(u_pos.x + shift * Mathf.Cos(angle), u_pos.y + shift * Mathf.Sin(angle), 0);
            }
        }
    }
}
