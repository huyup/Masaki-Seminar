using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// これはステージ4全般をコントロールするクラス
/// 作成者:huyup
/// </summary>
public class Stage4Script : MonoBehaviour
{
    //参照
    const int bedMachine_Count = 3;
    GameObject[] bedMachine=new GameObject[bedMachine_Count];

    GameObject pressMachine;
    GameObject pressMachine2;

    //パラメータ
    public static string bedMachineName = "ベッド１";
    public float elasticity = 3;

    public static string bedMachineName2 = "ベッド２";
    public float elasticity2 = 3;

    public static string bedMachineName3 = "ベッド３";
    public float elasticity3 = 3;

    public static string pressMachineName = "プレス機１";
    public float distanceToRight = 3.5f;
    public float distanceToLeft = -4f;
    public float rightSpeed = 3f;
    public float leftSpeed = 3f;

    public static string pressMachineName2 = "プレス機２";
    public float distanceToRight2 = 14f;
    public float distanceToLeft2 = 6.5f;
    public float rightSpeed2 = 3f;
    public float leftSpeed2 = 3f;

    public void ResetStage()
    {
        pressMachine.GetComponent<PressMachineHorizontal>().ResetPressMachine();
        pressMachine2.GetComponent<PressMachineHorizontal>().ResetPressMachine();

        pressMachine2.GetComponent<PressMachineHorizontal>().fallenEnable = true;
    }

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < bedMachine_Count; i++)
        {
            bedMachine[i] = GameObject.Find("bed" + (i + 1));
        }

        bedMachine[0].GetComponent<BedMachineScript>().InitializeParameter(elasticity);
        bedMachine[1].GetComponent<BedMachineScript>().InitializeParameter(elasticity2);
        bedMachine[2].GetComponent<BedMachineScript>().InitializeParameter(elasticity3);


        pressMachine = GameObject.Find("PressMachineSet1");
        pressMachine.GetComponent<PressMachineHorizontal>().InitializeParameter
            (distanceToRight,distanceToLeft,rightSpeed,leftSpeed);

        pressMachine2 = GameObject.Find("PressMachineSet2");
        pressMachine2.GetComponent<PressMachineHorizontal>().InitializeParameter
            (distanceToRight2, distanceToLeft2, rightSpeed2, leftSpeed2);
        pressMachine2.GetComponent<PressMachineHorizontal>().fallenEnable = true;
    }

    // Update is called once per frame
    void Update()
    {
        pressMachine.GetComponent<PressMachineHorizontal>().SetTrapHorizontal();
        pressMachine2.GetComponent<PressMachineHorizontal>().SetTrapHorizontal();

        if (UIScript.parameter_ChangeEnable)
            SetParameterInRealTime();
    }
    /// <summary>
    /// これはリアルタイムでパラメータを反映させる関数
    /// </summary>
    void SetParameterInRealTime()
    {
        bedMachine[0].GetComponent<BedMachineScript>().InitializeParameter(elasticity);
        bedMachine[1].GetComponent<BedMachineScript>().InitializeParameter(elasticity2);
        bedMachine[2].GetComponent<BedMachineScript>().InitializeParameter(elasticity3);

        pressMachine.GetComponent<PressMachineHorizontal>().InitializeParameter
    (distanceToRight, distanceToLeft, rightSpeed, leftSpeed);
        pressMachine2.GetComponent<PressMachineHorizontal>().InitializeParameter
    (distanceToRight2, distanceToLeft2, rightSpeed2, leftSpeed2);
    }
}
