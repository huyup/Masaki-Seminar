using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// これはステージ1全般をコントロールするクラス
/// 作成者:huyup
/// </summary>
public class Stage7Script : MonoBehaviour
{
    const int fallFloorMax = 32;
    //参照
    GameObject FallenTrap;
    GameObject FallenTrap2;

    GameObject[] fallFloor;
    //パラメータ
    public static string fallenTrapName = "プレス機１";
    public float fallenSpeed = 0.1f;
    public float raiseSpeed = -0.01f;

    public float distanceToTop = 5.5f;
    public float distanceToBottom = 1;

    public static string fallenTrapName2 = "プレス機2";
    public float fallenSpeed2 = 0.1f;
    public float raiseSpeed2 = -0.1f;

    public float distanceToTop2 = 5.5f;
    public float distanceToBottom2 = 1;

    // Use this for initialization
    void Start()
    {
        FallenTrap = GameObject.Find("FallenTrapSet");
        FallenTrap2 = GameObject.Find("FallenTrapSet2");
        FallenTrap.GetComponent<PressMachineTrapScript>().InitializeParameter(distanceToTop, distanceToBottom, fallenSpeed, raiseSpeed);
        FallenTrap2.GetComponent<PressMachineTrapScript>().InitializeParameter(distanceToTop2, distanceToBottom2, fallenSpeed2, raiseSpeed2);

        fallFloor = new GameObject[fallFloorMax];
        for (int i = 0; i < fallFloorMax; i++) 
        {
            fallFloor[i] = GameObject.Find("FallFloor (" + i.ToString() + ")");
        }
    }

    public void ResetStage()
    {
        FallenTrap.GetComponent<PressMachineTrapScript>().ResetPressMachine();
        FallenTrap2.GetComponent<PressMachineTrapScript>().ResetPressMachine();

        for (int i = 0; i < fallFloorMax; i++)
        {
            fallFloor[i].GetComponent<FallFloor>().ResetFallFloor();
        }
    }

    // Update is called once per frame
    void Update()
    {
        FallenTrap.GetComponent<PressMachineTrapScript>().SetTwoWaysTrap();
        FallenTrap2.GetComponent<PressMachineTrapScript>().SetTwoWaysTrap();

        if (UIScript.parameter_ChangeEnable)
            SetParameterInRealTime();
    }
    /// <summary>
    /// これはリアルタイムでパラメータを反映させる関数
    /// </summary>
    void SetParameterInRealTime()
    {
        FallenTrap.GetComponent<PressMachineTrapScript>().InitializeParameter(distanceToTop, distanceToBottom, fallenSpeed, raiseSpeed);
        FallenTrap2.GetComponent<PressMachineTrapScript>().InitializeParameter(distanceToTop2, distanceToBottom2, fallenSpeed2, raiseSpeed2);
    }
}
