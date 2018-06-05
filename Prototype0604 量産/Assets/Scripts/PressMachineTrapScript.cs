using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// これは罠：プレス機をコントロールするクラス
/// 作成者:huyup
/// </summary>
public class PressMachineTrapScript : MonoBehaviour
{
    bool fallenEnable;

    float DistanceToTop { get; set; }
    float DistanceToBottom { get; set; }
    float FallenVeloc { get; set; }
    float RaiseVeloc { get; set; }

    // Use this for initialization
    void Start()
    {
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
    public void SetTwoWaysTrap()
    {
        if (fallenEnable)
        {
            if (transform.position.y > DistanceToBottom)
            {
                transform.position -= new Vector3(0, FallenVeloc, 0);
            }
            else
            {
                fallenEnable = !fallenEnable;
            }
        }
        else
        {
            if (transform.position.y < DistanceToTop)
            {
                transform.position += new Vector3(0, RaiseVeloc, 0);
            }
            else
            {
                fallenEnable = !fallenEnable;
            }
        }
    }
}
