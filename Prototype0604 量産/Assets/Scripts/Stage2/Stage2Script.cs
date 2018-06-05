using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// これはステージ２全般をコントロールするクラス
/// 作成者:huyup
/// </summary>
public class Stage2Script : MonoBehaviour
{
    //参照
    const int fallenNeedle_count = 3;
    GameObject[] fallenNeedle = new GameObject[fallenNeedle_count];

    const int remoteFloor_Count = 2;
    GameObject[] remoteFloor = new GameObject[remoteFloor_Count];
    GameObject remoteFloorSwitch;

    GameObject fallenStoneSwitch;
    GameObject stone;

    //パラメータ（エディタから編集可能）
    public float Needle_FallenVeloc = -2;

    public float Stone_FallenVeloc = -3;
    public float Stone_HitFloor_AddForce = -15;
    
    public float FallenNeedle_To_Next_distance = 2;
    
    public float RemoteFloor1_MaxBottomY = -2;
    public float RemoteFloor2_MaxBottomY = -1;
    public float RemoteFloor_FallenVeloc = -0.02f;

    // Use this for initialization
    void Start()
    {
        //参照初期化
        for (int i = 0; i < fallenNeedle_count; i++)
        {
            fallenNeedle[i] = GameObject.Find("FallenNeedle" + (i + 1));
        }

        for (int i = 0; i < remoteFloor_Count; i++)
        {
            remoteFloor[i] = GameObject.Find("RemoteFloor" + (i + 1));
        }

        stone = GameObject.Find("Stone");

        remoteFloorSwitch = GameObject.Find("RemoteSwitch");

        fallenStoneSwitch = GameObject.Find("FallenStoneSwitch");
        
        //パラメータ設定
        for (int i = 0; i < fallenNeedle_count; i++)
        {
            fallenNeedle[i].GetComponent<FallenNeedleScript>().InitializeParameter(Needle_FallenVeloc);
        }

        remoteFloor[0].GetComponent<RemoteFloorScript>().InitializeParameter(RemoteFloor1_MaxBottomY, RemoteFloor_FallenVeloc);
        remoteFloor[1].GetComponent<RemoteFloorScript>().InitializeParameter(RemoteFloor2_MaxBottomY, RemoteFloor_FallenVeloc);

        stone.GetComponent<FallenStoneScript>().InitializeParameter(Stone_FallenVeloc, Stone_HitFloor_AddForce);
    }

    // Update is called once per frame
    void Update()
    {
        //スイッチを踏んだら、岩を移動させる
        if (fallenStoneSwitch.GetComponent<SwitchScript>().trapEnable)
        {
            stone.GetComponent<FallenStoneScript>().fallenEnable = true;
            fallenStoneSwitch.GetComponent<SwitchScript>().trapEnable = false;
        }

        //スイッチを踏んだら、針と床両方を落下させる
        if (remoteFloorSwitch.GetComponent<SwitchScript>().trapEnable)
        {
            //床
            for (int i = 0; i < remoteFloor_Count; i++)
            {
                remoteFloor[i].GetComponent<RemoteFloorScript>().fallenEnable = true;
            }
            //矢
            fallenNeedle[0].GetComponent<FallenNeedleScript>().SetNeedleFallen();

            remoteFloorSwitch.GetComponent<SwitchScript>().trapEnable = false;
        }

        FallenByDistance(fallenNeedle_count);

        if (UIScript.parameter_ChangeEnable)
        {
            SetParameterInRealTime();
        }
    }
    /// <summary>
    /// これはリアルタイムでパラメータを反映させる関数
    /// </summary>
    public void SetParameterInRealTime()
    {

            for (int i = 0; i < fallenNeedle_count; i++)
            {
                fallenNeedle[i].GetComponent<FallenNeedleScript>().InitializeParameter(Needle_FallenVeloc);
            }

            remoteFloor[0].GetComponent<RemoteFloorScript>().InitializeParameter(RemoteFloor1_MaxBottomY, RemoteFloor_FallenVeloc);
            remoteFloor[1].GetComponent<RemoteFloorScript>().InitializeParameter(RemoteFloor2_MaxBottomY, RemoteFloor_FallenVeloc);

            stone.GetComponent<FallenStoneScript>().InitializeParameter(Stone_FallenVeloc, Stone_HitFloor_AddForce);
        
    }

    /// <summary>
    /// これは針を一個ずつ落下させる関数
    /// </summary>
    /// <param name="fallenNeedle_count"></param>
    public void FallenByDistance(int fallenNeedle_count)
    {
        if (!fallenNeedle[fallenNeedle_count - 1].GetComponent<FallenNeedleScript>().fallenEnable)
        {
            for (int i = 0; i < fallenNeedle_count; i++)
            {
                if (i != 0)
                {
                    if (fallenNeedle[i].transform.position.y - fallenNeedle[i - 1].transform.position.y > FallenNeedle_To_Next_distance)
                    {
                        fallenNeedle[i].GetComponent<FallenNeedleScript>().fallenEnable = true;
                    }
                }
            }
        }
    }

}
