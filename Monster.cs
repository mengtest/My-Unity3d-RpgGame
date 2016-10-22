using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {
    public Transform cplayer;
    public Animator Ani;
    public float speed, Ispeed;
    public Vector3 dir;
    public float J_time;
    public float JumpSpeed;
    public int bt;
    private int Attack_status;
    private int Dead_status;
    public bool isLife;
    void Start()
    {
        speed = 0;
        Ispeed = this.transform.GetComponent<Self_class>().s_speed;
        dir = Vector3.zero;
        JumpSpeed = 0;
        Attack_status = 2;
        Dead_status = 2;
        isLife = true;
    }
    // Update is called once per frame
    void Attack_end(int status)
    {
        Attack_status = status;
    }
    void Update()
    {
        isLife = this.GetComponent<Self_class>().isLife;
        CharacterController controller = GetComponent<CharacterController>();
        if (!controller.isGrounded)
        {
            Ispeed = 0;
            JumpSpeed -= 98 * Time.deltaTime;
            if (JumpSpeed < 0)
                speed = 0;
        }
        else
        {
            JumpSpeed = 0;
        }
        if (isLife)
        {
            if (Attack_status != 1)
            {
                this.transform.parent.FindChild("Spell").GetComponent<HandAttack>().Work(this.transform);
                Attack_status = 1;
            }
        }
        else
        {
            Ispeed = 0;
            speed = 0;
            if (Dead_status == 2)
            {
                //Ani.SetInteger("Attack", attack);
                Ani.SetFloat("Speed", speed);
                Ani.SetBool("isLife", isLife);
                Dead_status = 1;
            }
        }
        //Ani.SetInteger("Attack", attack);
        Ani.SetFloat("Speed", speed);
        dir = (cplayer.forward * speed * Ispeed) + (cplayer.up * JumpSpeed);
        //controller.Move(cplayer.up * JumpSpeed * Time.deltaTime);
        controller.Move(dir * Time.deltaTime);
    }
}
