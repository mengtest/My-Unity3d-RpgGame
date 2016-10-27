using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
    public Transform cplayer;
    public Animator Ani;
    public float speed,Ispeed;
    public Vector3 dir;
    public float J_time;
    public float JumpSpeed;
    public int bt;
    private int Attack_status;
    private int Dead_status;
    private bool isLife;
    public bool isCastingComplete;
    public int Spell_status;
	void Start ()
    {
        speed = 0;
        Ispeed = this.transform.GetComponent<Self_class>().s_speed;
        dir = Vector3.zero;
        JumpSpeed = 0;
        Attack_status = 2;
        Dead_status = 2;
        Spell_status = 2;
        isLife = true;
        isCastingComplete = true;
    }
	// Update is called once per frame
    public void player_act_cast(int spell_id)
    {
        if (Spell_status != 1)
        {
            Spell_status = 1;
            this.transform.parent.FindChild("Spell").GetComponent<Spell_cast>().casting(spell_id, this.transform);
        }

    }
    void Attack_end(int status)
    {
        Ani.SetBool("isAttack", false);
        Attack_status = status;
    }
    void Spell_end(int status)
    {
        Ani.SetBool("isSpell_1", false);
        Spell_status = status;
    }
    void fs_control()
    {
        if (Input.GetKey(KeyCode.W) || GameObject.Find("B_Up").GetComponent<OnButtonPressed>().Deal == "KeyDown")
        {
            speed = 1;
            Ispeed = this.transform.GetComponent<Self_class>().s_speed; 
            //dir = Vector3.forward * speed * Ispeed;
        }
        else if (Input.GetKeyUp(KeyCode.W) || GameObject.Find("B_Up").GetComponent<OnButtonPressed>().Deal == "KeyUp")
        {
            speed = 0;
            Ispeed = 0;
        }
        if (Input.GetKey(KeyCode.S) || GameObject.Find("B_Down").GetComponent<OnButtonPressed>().Deal == "KeyDown")
        {
            speed = 1;
            Ispeed = -(this.transform.GetComponent<Self_class>().s_speed);
            //dir = Vector3.forward * speed * Ispeed;
        }
        else if (Input.GetKeyUp(KeyCode.S) || GameObject.Find("B_Down").GetComponent<OnButtonPressed>().Deal == "KeyUp")
        {
            speed = 0;
            Ispeed = 0;
        }
        if (Input.GetKey(KeyCode.A) || GameObject.Find("B_Left").GetComponent<OnButtonPressed>().Deal == "KeyDown")
            cplayer.Rotate(-Vector3.up * 120 * Time.deltaTime);
        if (Input.GetKey(KeyCode.D) || GameObject.Find("B_Right").GetComponent<OnButtonPressed>().Deal == "KeyDown")
            cplayer.Rotate(-Vector3.down * 120 * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.H) || GameObject.Find("B_A").GetComponent<OnButtonPressed>().Deal == "KeyDown")
        {
            if (Attack_status != 1)
            {
                this.transform.parent.FindChild("Spell").GetComponent<Spell_cast>().casting(101,this.transform);
                Attack_status = 1;
            }
        }
    }
    void sp_control()
    {
        //if((Input.GetKey(KeyCode.W)||GameObject.Find("Player_CAnvas").transform.FindChild("B_Up").GetComponent<OnButtonPressed>().Deal == "KeyDown")&& GameObject.Find("Player_CAnvas").transform.FindChild("B_B").GetComponent<OnButtonPressed>().Deal == "KeyDown")
        //{
        //    if (isCastingComplete)
        //    {
        //        isCastingComplete = false;
        //        this.transform.parent.FindChild("Spell").GetComponent<Spell_cast>().casting(102, this.transform);
        //    }
        //}
        //if ((Input.GetKey(KeyCode.D) || GameObject.Find("Player_CAnvas").transform.FindChild("B_Right").GetComponent<OnButtonPressed>().Deal == "KeyDown") && GameObject.Find("Player_CAnvas").transform.FindChild("B_B").GetComponent<OnButtonPressed>().Deal == "KeyDown")
        //{
        //    if (Spell_status!=1)
        //    {
        //        Spell_status = 1;
        //        this.transform.parent.FindChild("Spell").GetComponent<Spell_cast>().casting(103, this.transform);
        //    }
        //}
    }
	void Update () {
        CharacterController controller = GetComponent<CharacterController>();
        isLife = this.GetComponent<Self_class>().isLife;
        if (!controller.isGrounded)
        {
            Ispeed = 0;
            JumpSpeed -= 98 * Time.deltaTime;
            if (JumpSpeed < 0)
            {
                speed = 0;
            }
            //controller.Move(Vector3.down * JumpSpeed*Time.deltaTime);
            //Ani.SetFloat("Speed", speed);
        }
        else
        {
            JumpSpeed = 0;
            if (this.transform.FindChild("ejector"))
            {
                GameObject.Destroy(this.transform.FindChild("ejector").gameObject);
                this.transform.GetComponent<Self_class>().s_speed = 5;
            }
        }
        if (isLife)
        {
            fs_control();
            sp_control();
            if ((Input.GetKey(KeyCode.Space) || GameObject.Find("B_O").GetComponent<OnButtonPressed>().Deal == "KeyDown") && controller.isGrounded)         //Junp
            {
                speed = 2;
                JumpSpeed = 20;
                Ani.SetFloat("Speed", speed);
            }
        }
        else
        {
            Ispeed = 0;
            speed = 0;
            if (Dead_status == 2)
            {
                Ani.SetBool("isAttack", false);
                Ani.SetFloat("Speed", speed);
                Ani.SetBool("isLife", isLife);
                Dead_status = 1;
            }
        }
        //Ani.SetInteger("Attack", a);
        Ani.SetFloat("Speed", speed);
        dir = (cplayer.forward * speed * Ispeed)+ (cplayer.up * JumpSpeed);
        //controller.Move(cplayer.up * JumpSpeed * Time.deltaTime);
        controller.Move(dir* Time.deltaTime);
    }
    public void Move()
    {
        CharacterController controller = GetComponent<CharacterController>();
        dir = (cplayer.forward * speed * Ispeed) + (cplayer.up * JumpSpeed);
        controller.Move(dir * Time.deltaTime);
    }
}
