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
    public  void injured(float damage)
    {
        p_life -= damage;
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
 *        Master:怪物类
 *        Item:物品类
 *        
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
 * */
