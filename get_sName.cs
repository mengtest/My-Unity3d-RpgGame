using UnityEngine;
using System.Collections;

public class get_sName : MonoBehaviour {
    public string Item_name(int sid)
    {
        string sname;
        switch (sid)
        {
            case 20001:
                sname = "木材";
                break;
            case 20002:
                sname = "石材";
                break;
            case 20003:
                sname = "草藤";
                break;
            case 20004:
                sname = "动物皮毛";
                break;
            default:
                sname = "无定义";
                break;
        }
        return sname;
    }
    public string Item_content(int sid)
    {
        string scontent;
        switch (sid)
        {
            case 20001:
                scontent = "  基本制作材料，用于合成，无法直接使用";
                break;
            case 20002:
                scontent = "  基本制作材料，用于合成，无法直接使用";
                break;
            case 20003:
                scontent = "  基本制作材料，用于合成，无法直接使用";
                break;
            case 20004:
                scontent = "  基本制作材料，用于合成，无法直接使用";
                break;
            default:
                scontent = "Null";
                break;
        }
        return scontent;
    }
}
