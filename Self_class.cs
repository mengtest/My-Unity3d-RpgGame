using UnityEngine;
using System.Collections;
public class Self_class : MonoBehaviour {
    public string s_class;
    public int s_id;
    public float s_life;
    public float s_speed;
    public string s_name;
    public string s_Icontent;
    public float s_AttackValue;
    private float p_life;
    public bool isLife;
    public string s_iType;
    public int s_iCount=1;
    public  void injured(float damage)
    {
        p_life -= damage;
    }
    public void Heal(float heal_v)
    {
        if (isLife)
        {
            if (p_life+heal_v>s_life)
            {
                p_life = s_life;
            }
            else
            {
                p_life += heal_v;
            }
        }
    }
    public float getLife()
    {
        return p_life;
    }
    void Start()
    {
        isLife = true;
        p_life = s_life;
    }
    void Update()
    {
        isLife = (p_life > 0 ? true : false);
    }
}
/*s_class:
 *        Unit:单位类
 *        Item:物品类
 *        Hero:英雄类
 *        
 * 
 * s_id:
 *         10->:怪物类
 *         20->:物品类
 *       
 *       20：
 *          20001：木材
 *          20002：石材
 *          20003：动物皮毛
 *          20004：草藤
 *          20005:治疗药剂
 *          20006：弓箭
 *          20007:火弩
 *          2008：火箭喷射机
 * s_iType:
 *         equi:装备类 使用无消耗
 *         prop:道具类 使用有消耗
 * */
