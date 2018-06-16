using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// これはステージ8全般をコントロールするクラス
/// 作成者:huyup
/// </summary>
public class Stage8Script : MonoBehaviour
{
    //参照
    const int translateMachineCount = 4;
    GameObject[] translateMachine = new GameObject[translateMachineCount];

    const int fireTrapCount = 5;
    GameObject[] fireTrapMachine = new GameObject[fireTrapCount];

    //パラメータ
    public static string mshinItoName = "転送装置";
    public float translateVeloc = 3;
    public float topPos_Y = 5;
    public float bottomPos_Y = 5;


    public static string fireTrapName = "点火装置";
    public int eruption = 60;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < translateMachineCount; i++)
        {
            translateMachine[i] = GameObject.Find("TranslateMachince" + (i + 1));
        }

        for (int i = 0; i < translateMachineCount; i++)
        {
            translateMachine[i].GetComponent<TranslateMachinceScript>().InitializeParameter
                (translateVeloc, topPos_Y, bottomPos_Y);
        }

        for (int i = 0; i < fireTrapCount; i++)
        {
            fireTrapMachine[i] = GameObject.Find("Pf_Trap_Fire" + (i + 1));
        }

        for (int i = 0; i < fireTrapCount; i++)
        {
            fireTrapMachine[i].GetComponent<FireTrapScript>().InitializeParameter(eruption);
        }
    }

    public void ResetStage()
    {
        for (int i = 0; i < translateMachineCount; i++)
        {
            translateMachine[i].GetComponent<TranslateMachinceScript>().ResetTranslateMachine();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < fireTrapCount; i++)
        {
            fireTrapMachine[i].GetComponent<FireTrapScript>().SetFireTrap();
        }
        if (UIScript.parameter_ChangeEnable)
            SetParameterInRealTime();
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < translateMachineCount; i++)
        {
            translateMachine[i].GetComponent<TranslateMachinceScript>().MoveFloorHorizontal();
        }
    }
    /// <summary>
    /// これはリアルタイムでパラメータを反映させる関数
    /// </summary>
    void SetParameterInRealTime()
    {
        for (int i = 0; i < translateMachineCount; i++)
        {
            translateMachine[i].GetComponent<TranslateMachinceScript>().InitializeParameter
                (translateVeloc, topPos_Y, bottomPos_Y);
        }

        for (int i = 0; i < fireTrapCount; i++)
        {
            fireTrapMachine[i].GetComponent<FireTrapScript>().InitializeParameter(eruption);
        }
    }
}
