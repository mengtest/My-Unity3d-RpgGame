using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class Pocket_dash_current : MonoBehaviour,IPointerClickHandler
{
    public string keyname;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (keyname == "drop")
        {
            this.transform.parent.GetComponent<Pocket_Dashboard>().drop();
        }
        else if (keyname == "close")
        {
            this.transform.parent.GetComponent<Pocket_Dashboard>().close();
        }
        else if (keyname == "shortcut")
        {
            this.transform.parent.GetComponent<Pocket_Dashboard>().shortcut();
        }
        else if (keyname == "use")
        {
            this.transform.parent.GetComponent<Pocket_Dashboard>().use();
        }
    }
}
