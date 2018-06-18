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
    public float translateVeloc = 2;
    public float bottomPos_Y = 0.5f;
    public float topPos_Y = 9;

    public static string fallenFloorName = "落ちる床";
    public float fallenVeloc = 3;
    public float countToFallen = 6000;

    // Use this for initialization
    void Start()
    {
        fallenFloor = GameObject.Find("FallenFloor");
        fallenFloor2 = GameObject.Find("FallenFloor2");

        fallenFloor.GetComponent<FallFloor>().InitializeParameter(fallenVeloc, countToFallen);
        fallenFloor2.GetComponent<FallFloor>().InitializeParameter(fallenVeloc, countToFallen);

        for (int i = 0; i < translateMachineCount; i++)
        {
            translateMachine[i] = GameObject.Find("TranslateMachince" + (i + 1));
        }
        for (int i = 0; i < translateMachineCount; i++)
        {
            translateMachine[i].GetComponent<TranslateMachinceScript>().InitializeParameter
                (translateVeloc, topPos_Y,bottomPos_Y);
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
        if (UIScript.parameter_ChangeEnable)
            SetParameterInRealTime();
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < translateMachineCount; i++)
        {
            translateMachine[i].GetComponent<TranslateMachinceScript>().MoveFloorVertical();
        }
    }
    /// <summary>
    /// これはリアルタイムでパラメータを反映させる関数
    /// </summary>
    void SetParameterInRealTime()
    {
        fallenFloor.GetComponent<FallFloor>().InitializeParameter(fallenVeloc, countToFallen);

        for (int i = 0; i < translateMachineCount; i++)
        {
            translateMachine[i].GetComponent<TranslateMachinceScript>().InitializeParameter
                (translateVeloc, topPos_Y, bottomPos_Y);
        }
    }
}
