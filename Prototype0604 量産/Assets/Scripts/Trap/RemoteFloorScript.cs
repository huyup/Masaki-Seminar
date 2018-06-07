using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// これは罠：落ちる床をコントロールするクラス
/// 作成者:huyup
/// </summary>
public class RemoteFloorScript : MonoBehaviour
{
    public bool fallenEnable;
    float MaxBottomY { get; set; }
    float FallenVeloc { get; set; }

    Vector3 remoteFloorInitPos;

    // Use this for initialization
    void Start()
    {
        remoteFloorInitPos = transform.position;
    }

    public void ResetRemoteFloor()
    {
        fallenEnable = false;
        transform.position = remoteFloorInitPos;
    }

    public void InitializeParameter(float _MaxBottomY,float _FallenVeloc)
    {
        MaxBottomY = _MaxBottomY;
        FallenVeloc = _FallenVeloc;
    }

    // Update is called once per frame
    void Update()
    {
        if (fallenEnable)
        {
            SetFallenDown();
        }
    }

    public void SetFallenDown()
    {
        if (transform.localPosition.y - MaxBottomY > 0.1f)
        {
            transform.localPosition += new Vector3(0, FallenVeloc, 0);
        }
        else
        {
            fallenEnable = false;
        }
    }
}
