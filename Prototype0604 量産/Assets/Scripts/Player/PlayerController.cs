using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 必要なコンポーネントの列記
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    #region フィールド
    public const float DistanceToGround = 0.3f;

    //変更できるコンポーネント
    public float animSpeed = 1.5f;
    public float Speed = 7.0f;
    public float jumpPower = 8.0f;

    public float g_VeclocityX;
    bool duringRun = false;
    bool canInput;
    bool canControlPlayer;

    public bool P_CanControlPlayer
    {
        get { return canControlPlayer; }
        set { canControlPlayer = value; }
    }

    public float g_VeclocityY;


    //方向変更用
    ChangeRotation changeRotation;

    // ジャンプ
    public bool g_duringJump = false;

    private Rigidbody rb;
    private Vector3 velocity;
    private Vector3 playerInitPos;
    private Animator anim;

    public bool isGround = false;
    public bool airJumpEnable = false;

    public const int MAXINITCOUNT = 50;
    public int initCount = MAXINITCOUNT;
    #endregion

    // Use this for initialization
    void Start()
    {
        playerInitPos = this.gameObject.transform.position;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        changeRotation = new ChangeRotation();
        canControlPlayer = true;
        canInput = false;
    }

    public void ResetPlayer()
    {
        this.gameObject.transform.position = playerInitPos;
        this.gameObject.transform.eulerAngles = new Vector3(0, 90, 0);

        this.gameObject.SendMessage("ResetLife");

        changeRotation.ResetRotation();
        rb.velocity = Vector3.zero;
        velocity = Vector3.zero;

        g_VeclocityX = 0;
        canInput = false;
        initCount = MAXINITCOUNT;
    }

    // Update is called once per frame
    void Update()
    {
        if (initCount > -5)
        {
            initCount--;
        }
        rb.useGravity = true;
        CheckisGrounded();
        UpdateAnimator();
        UpdateInput();
    }

    void FixedUpdate()
    {
        if (Time.timeScale == 0)
            return;

        //クリア時のアニメーション
        if (!canControlPlayer)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.localPosition += Vector3.forward * Time.fixedDeltaTime;
            return;
        }
        Move();
        Jump();
        changeRotation.ChangeDirection(g_VeclocityX, this.gameObject);

        if (airJumpEnable)
        {
            if (Input.GetButtonDown("Jump"))
            {
                anim.SetBool("Jump", true);
                rb.AddForce(Vector3.up *
    jumpPower, ForceMode.VelocityChange);
                airJumpEnable = false;
            }

        }
    }
    #region 移動に関連する
    void Move()
    {
        velocity = new Vector3(g_VeclocityX, 0, 0);
        velocity *= Speed;

        if (!changeRotation.P_TurnOverEnable && canInput)
            transform.localPosition += velocity * Time.fixedDeltaTime;
    }

    void Jump()
    {
        if (g_duringJump)
        {
            rb.AddForce(Vector3.up *
                jumpPower, ForceMode.VelocityChange);
            g_duringJump = false;
            // airJumpEnable = false;
        }
        else
        {
            rb.velocity += Physics.gravity * Time.deltaTime;
        }
    }
    #endregion

    #region input animator更新
    void UpdateInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)
            || (int)Input.GetAxis("Horizontal") == 0)
            canInput = true;

        if (canInput)
            g_VeclocityX = Input.GetAxis("Horizontal");



        g_VeclocityY = Input.GetAxis("Vertical");


        if (Input.GetButtonDown("Jump"))
        {
            if ((isGround || airJumpEnable) && !anim.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            {
                g_duringJump = true;
                anim.SetBool("Jump", true);
            }
        }

        if (g_VeclocityX > 0 || g_VeclocityX < 0)
            duringRun = true;
        else
            duringRun = false;
    }

    void UpdateAnimator()
    {
        anim.SetBool("Jump", false);
        anim.SetBool("Run", duringRun);
        anim.speed = animSpeed;
    }
    #endregion

    void CheckisGrounded()
    {
        RaycastHit hit;
        Ray[] ray = new Ray[20];
        for (int i = 0; i < 20; i++)
        {
            ray[i] = new Ray(transform.position - new Vector3(0.10f, 0, 0) + new Vector3(0.012f * i, 0, 0), Vector3.down);
        }
        int count = 0;
        for (int i = 0; i < 20; i++)
        {
            if (Physics.Raycast(ray[i], out hit, DistanceToGround))
            {
                isGround = true;
                break;
            }
            else
            {
                count++;
            }

        }
        if (count == 20)
        {
            isGround = false;
            //airJumpEnable = false;
        }

    }
}
