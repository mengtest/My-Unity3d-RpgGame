using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Pan_short_signal : MonoBehaviour,IPointerDownHandler,IPointerUpHandler {
    public Sprite[] signal_source;
    public bool isSet;
    public string content;
    void Start()
    {
        this.transform.parent.FindChild("Issue").gameObject.SetActive(false);
    }
    public void change()
    {
        if (isSet)
        {
            this.transform.GetComponent<Image>().sprite = signal_source[0];
        }
        else
        {
            this.transform.GetComponent<Image>().sprite = signal_source[1];
        }
    }
    public void OnPointerDown(PointerEventData eventdata)
    {
        this.transform.parent.FindChild("Issue").gameObject.SetActive(true);
        this.transform.parent.FindChild("Issue").GetComponent<Text>().text = content;
        this.transform.parent.FindChild("Issue").position = new Vector3(eventdata.position.x+110, eventdata.position.y-60, 0);
    }
    public void OnPointerUp(PointerEventData eventdata)
    {
        this.transform.parent.FindChild("Issue").gameObject.SetActive(false);
    }
}
