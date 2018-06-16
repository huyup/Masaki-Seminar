using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// これは罠：プレス機をコントロールするクラス
/// 作成者:huyup
/// </summary>
public class PressMachineHorizontal : MonoBehaviour
{
    bool fallenEnable;

    float DistanceToRight { get; set; }
    float DistanceToLeft { get; set; }
    float RightVeloc { get; set; }
    float LeftVeloc { get; set; }

    Vector3 pressMachInitPos;

    // Use this for initialization
    void Start()
    {
        pressMachInitPos = transform.position;
    }

    public void ResetPressMachine()
    {
        fallenEnable = false;
        transform.position = pressMachInitPos;
    }

    public void InitializeParameter(float _DistanceToRight, float _DistanceToLeft, float _RightVeloc, float _LeftVeloc)
    {
        DistanceToRight = _DistanceToRight;
        DistanceToLeft = _DistanceToLeft;
        RightVeloc = _RightVeloc;
        LeftVeloc = _LeftVeloc;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }
    /// <summary>
    /// プレス機を左右運動させるメソッド
    /// </summary>
    public void SetTrapHorizontal()
    {
        if (fallenEnable)
        {
            if (transform.position.x > DistanceToLeft)
            {
                transform.localPosition += new Vector3(LeftVeloc, 0, 0);
            }
            else
            {
                fallenEnable = !fallenEnable;
            }
        }
        else
        {
            if (transform.position.x < DistanceToRight)
            {
                transform.localPosition += new Vector3(RightVeloc, 0, 0);
            }
            else
            {
                fallenEnable = !fallenEnable;
            }
        }
    }
}
