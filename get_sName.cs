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
            case 20005:
                sname = "治疗药剂";
                break;
            case 20006:
                sname = "弓箭";
                break;
            case 20007:
                sname = "火弩";
                break;
            case 20008:
                sname = "火箭喷射机";
                break;
            case 20009:
                sname = "火焰喷雾";
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
            case 20005:
                scontent = "  基本战斗道具，使用后可直接恢复100点生命";
                break;
            case 20006:
                scontent = "  初级战斗器械，冷却时间：9，射速：中，伤害：150";
                break;
            case 20007:
                scontent = "  中级战斗器械，冷却时间：3，射速：快，伤害：180";
                break;
            case 20008:
                scontent = "  中级战斗器械，冷却时间：8，提供跳跃初始速度：90";
                break;
            case 20009:
                scontent = "  中级战斗器械，冷却时间：2，每秒伤害：80，移动速度降低：4,伤害范围：4";
                break;
            default:
                scontent = "Null";
                break;
        }
        return scontent;
    }
    public int Item_Spell(int sid)
    {
        int sp_id;
        switch (sid)
        {
            case 20005:
                sp_id = 102;
                break;
            case 20006:
                sp_id = 103;
                break;
            case 20007:
                sp_id = 104;
                break;
            case 20008:
                sp_id = 105;
                break;
            case 20009:
                sp_id = 106;
                break;
            default:
                sp_id = 0;
                break;
        }
        return sp_id;
    }
}
