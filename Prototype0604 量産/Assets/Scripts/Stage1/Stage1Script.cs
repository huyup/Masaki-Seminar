using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// これはステージ1全般をコントロールするクラス
/// 作成者:huyup
/// </summary>
public class Stage1Script : MonoBehaviour
{
    //参照
    GameObject FallenTrap;
    GameObject FallenTrap2;
    //パラメータ
    public static string fallenTrapName = "プレス機１";
    public float fallenSpeed = 2f;
    public float raiseSpeed = 3f;

    public float distanceToTop = 7f;
    public float distanceToBottom = 1;

    public static string fallenTrapName2 = "プレス機2";
    public float fallenSpeed2 = 4f;
    public float raiseSpeed2 = 4f;

    public float distanceToTop2 = 7f;
    public float distanceToBottom2 = 1;

    // Use this for initialization
    void Start()
    {
        FallenTrap = GameObject.Find("FallenTrapSet");
        FallenTrap2 = GameObject.Find("FallenTrapSet2");
        FallenTrap.GetComponent<PressMachineVerticalScript>().InitializeParameter(distanceToTop, distanceToBottom, fallenSpeed, raiseSpeed);
        FallenTrap2.GetComponent<PressMachineVerticalScript>().InitializeParameter(distanceToTop2, distanceToBottom2, fallenSpeed2, raiseSpeed2);
    }

    public void ResetStage()
    {
        FallenTrap.GetComponent<PressMachineVerticalScript>().ResetPressMachine();
        FallenTrap2.GetComponent<PressMachineVerticalScript>().ResetPressMachine();
    }

    // Update is called once per frame
    void Update()
    {
        FallenTrap.GetComponent<PressMachineVerticalScript>().
            SetTrapVertical();

        FallenTrap2.GetComponent<PressMachineVerticalScript>().
            SetTrapVertical();
        
        if (UIScript.parameter_ChangeEnable)
        {
            SetParameterInRealTime();
        }


    }
    /// <summary>
    /// これはリアルタイムでパラメータを反映させる関数
    /// </summary>
    void SetParameterInRealTime()
    {

        FallenTrap.GetComponent<PressMachineVerticalScript>().InitializeParameter(distanceToTop, distanceToBottom, fallenSpeed, raiseSpeed);
        FallenTrap2.GetComponent<PressMachineVerticalScript>().InitializeParameter(distanceToTop2, distanceToBottom2, fallenSpeed2, raiseSpeed2);
    }
}
