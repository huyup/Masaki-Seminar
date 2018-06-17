using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// これは罠：プレス機をコントロールするクラス
/// 作成者:huyup
/// </summary>

public class PressMachineVerticalScript : MonoBehaviour
{
    bool fallenEnable;
    float deltaTime_Rigidbody;
    float total_Veloc;
    
    GameObject movingFloor;

    float DistanceToTop { get; set; }
    float DistanceToBottom { get; set; }
    float FallenVeloc { get; set; }
    float RaiseVeloc { get; set; }

    Rigidbody rb;
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
        movingFloor = transform.Find("MovingFloor").gameObject;

        translateInitPos = movingFloor.transform.position;
        defaultPos = movingFloor.transform.position;

        rb = movingFloor.gameObject.GetComponent<Rigidbody>();
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

    public void InitializeParameter(float _DistanceToTop,float _DistanceToBottom,float _FallenVeloc,float _RaiseVeloc)
    {
        DistanceToTop = _DistanceToTop;
        DistanceToBottom = _DistanceToBottom;
        FallenVeloc = _FallenVeloc;
        RaiseVeloc = _RaiseVeloc;
    }

    // Update is called once per frame
    void Update()
    {
    }
    /// <summary>
    /// プレス機を上下運動させるメソッド
    /// </summary>
    public void SetTrapVertical()
    {
        if (fallenEnable)
            total_Veloc = deltaTime_Rigidbody * RaiseVeloc;
        else
            total_Veloc = deltaTime_Rigidbody * FallenVeloc * -1;

        if (fallenEnable)
        {
            if (movingFloor.transform.localPosition.y < DistanceToTop)
            {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
                rb.MovePosition(new Vector3(translateInitPos.x ,
            translateInitPos.y+ total_Veloc,
            translateInitPos.z));
            }
            else
            {
                deltaTime_Rigidbody = 0;
                translateInitPos = movingFloor.transform.position;
                fallenEnable = false;
            }
        }
        else
        {
            if (movingFloor.transform.localPosition.y > DistanceToBottom)
            {
                rb.MovePosition(new Vector3(translateInitPos.x,
            translateInitPos.y + total_Veloc,
            translateInitPos.z));
            }
            else
            {
                translateInitPos = movingFloor.transform.position;
                deltaTime_Rigidbody = 0;
                fallenEnable = true;
            }
        }

        deltaTime_Rigidbody += Time.deltaTime;
    }
}
