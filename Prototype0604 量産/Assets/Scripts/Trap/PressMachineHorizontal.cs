using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// これは罠：プレス機を左右にコントロールするクラス
/// 作成者:huyup
/// </summary>
public class PressMachineHorizontal : MonoBehaviour
{
    public bool fallenEnable;
    float deltaTime_Rigidbody;
    float total_Veloc;

    Rigidbody rb;
    float DistanceToRight { get; set; }
    float DistanceToLeft { get; set; }
    float RightVeloc { get; set; }
    float LeftVeloc { get; set; }


    /// <summary>
    /// これは移動するときの初期位置の変数
    /// </summary>
    Vector3 translateInitPos;

    /// <summary>
    /// これは初期位置を記録するための変数
    /// 読み込み専用
    /// </summary>
    Vector3 defaultPos;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        translateInitPos = transform.position;
        defaultPos = transform.position;
    }

    public void ResetPressMachine()
    {
        deltaTime_Rigidbody = 0;
        total_Veloc = 0;

        fallenEnable = false;
        translateInitPos = defaultPos;
        rb.velocity = Vector3.zero;
        rb.MovePosition(new Vector3(defaultPos.x,
defaultPos.y,
defaultPos.z));
    }

    public void InitializeParameter(float _DistanceToRight, float _DistanceToLeft, float _RightVeloc, float _LeftVeloc)
    {
        DistanceToRight = _DistanceToRight;
        DistanceToLeft = _DistanceToLeft;
        RightVeloc = _RightVeloc;
        LeftVeloc = _LeftVeloc;
    }

    // Update is called once per frame
    void Update()
    {
    }
    /// <summary>
    /// プレス機を左右運動させるメソッド
    /// </summary>
    public void SetTrapHorizontal()
    {
        if (fallenEnable)
            total_Veloc = deltaTime_Rigidbody * RightVeloc;
        else
            total_Veloc = deltaTime_Rigidbody * LeftVeloc * -1;

        if (fallenEnable)
        {
            if (transform.position.x < DistanceToRight)
            {
                rb.MovePosition(new Vector3(translateInitPos.x + total_Veloc,
            translateInitPos.y,
            translateInitPos.z));
            }
            else
            {
                deltaTime_Rigidbody = 0;
                translateInitPos = transform.position;
                fallenEnable = false;
            }
        }
        else
        {
            if (transform.position.x > DistanceToLeft)
            {
                rb.MovePosition(new Vector3(translateInitPos.x + total_Veloc,
            translateInitPos.y,
            translateInitPos.z));
            }
            else
            {
                translateInitPos = transform.position;
                deltaTime_Rigidbody = 0;
                fallenEnable = true;
            }
        }

        deltaTime_Rigidbody += Time.deltaTime;
    }
}
