using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// これはステージ7全般をコントロールするクラス
/// 作成者:huyup
/// </summary>
public class Stage7Script : MonoBehaviour
{
    //参照
    const int translateMachineCount = 4;
    GameObject[] translateMachine = new GameObject[translateMachineCount];

    GameObject fallenFloor;
    GameObject fallenFloor2;
    //パラメータ
    public static string mshinItoName = "転送装置";
    public float translateVeloc = 3;
    public float bottomPosy = 5;
    public float topPosy = 5;

    public static string fallenFloorName = "落ちる床";
    public float fallenVeloc = 3;

    public static string fallenFloorName2 = "落ちる床２";
    public float fallenVeloc2 = 3;

    // Use this for initialization
    void Start()
    {
        fallenFloor = GameObject.Find("FallenFloor");
        fallenFloor2 = GameObject.Find("FallenFloor2");

        fallenFloor.GetComponent<FallFloor>().InitializeParameter(fallenVeloc);
        fallenFloor2.GetComponent<FallFloor>().InitializeParameter(fallenVeloc2);

        for (int i = 0; i < translateMachineCount; i++)
        {
            translateMachine[i] = GameObject.Find("TranslateMachince" + (i + 1));
        }
        for (int i = 0; i < translateMachineCount; i++)
        {
            translateMachine[i].GetComponent<TranslateMachinceScript>().InitializeParameter
                (translateVeloc, topPosy, bottomPosy);
        }
    }

    public void ResetStage()
    {
        fallenFloor.GetComponent<FallFloor>().ResetFallFloor();
        fallenFloor2.GetComponent<FallFloor>().ResetFallFloor();
        for (int i = 0; i < translateMachineCount; i++)
        {
            translateMachine[i].GetComponent<TranslateMachinceScript>().ResetTranslateMachine();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        translateMachine[0].GetComponent<TranslateMachinceScript>().SetTwoWayTranslateFloor();
        translateMachine[1].GetComponent<TranslateMachinceScript>().SetTwoWayTranslateFloor();
        translateMachine[2].GetComponent<TranslateMachinceScript>().SetTwoWayTranslateFloor();
        translateMachine[3].GetComponent<TranslateMachinceScript>().SetTwoWayTranslateFloor();

        if (UIScript.parameter_ChangeEnable)
            SetParameterInRealTime();
    }
    /// <summary>
    /// これはリアルタイムでパラメータを反映させる関数
    /// </summary>
    void SetParameterInRealTime()
    {
        fallenFloor.GetComponent<FallFloor>().InitializeParameter(fallenVeloc);
        fallenFloor2.GetComponent<FallFloor>().InitializeParameter(fallenVeloc2);

        for (int i = 0; i < translateMachineCount; i++)
        {
            translateMachine[i].GetComponent<TranslateMachinceScript>().InitializeParameter
                (translateVeloc, topPosy, bottomPosy);
        }
    }
}
