using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// これはステージ4全般をコントロールするクラス
/// 作成者:huyup
/// </summary>
public class Stage6Script : MonoBehaviour
{
    //参照
    const int bedMachine_Count = 6;
    GameObject[] bedMachine = new GameObject[bedMachine_Count];
    GameObject FallenTrap;

    //パラメータ
    #region parameter
    public static string fallenTrapName = "プレス機１";
    public float distanceToRight = 15;
    public float distanceToLeft = 6.5f;
    public float rightSpeed = 0.1f;
    public float leftSpeed = -0.1f;

    public static string bedMachineName = "ベッド１";
    public float elasticity = 3;

    public static string bedMachineName2 = "ベッド２";
    public float elasticity2 = 3;

    public static string bedMachineName3 = "ベッド３";
    public float elasticity3 = 3;

    public static string bedMachineName4 = "ベッド４";
    public float elasticity4 = 3;

    public static string bedMachineName5 = "ベッド５";
    public float elasticity5 = 3;

    public static string bedMachineName6 = "ベッド６";
    public float elasticity6 = 3;
    #endregion

    public void ResetStage()
    {
        FallenTrap.GetComponent<PressMachineHorizontal>().ResetPressMachine();
    }

    // Use this for initialization
    void Start()
    {
        FallenTrap = GameObject.Find("FallenTrapSet");
        FallenTrap.GetComponent<PressMachineHorizontal>().InitializeParameter(distanceToRight, distanceToLeft, rightSpeed, leftSpeed);

        for (int i = 0; i < bedMachine_Count; i++)
        {
            bedMachine[i] = GameObject.Find("bed" + (i + 1));
        }

        bedMachine[0].GetComponent<BedMachineScript>().InitializeParameter(elasticity);
        bedMachine[1].GetComponent<BedMachineScript>().InitializeParameter(elasticity2);
        bedMachine[2].GetComponent<BedMachineScript>().InitializeParameter(elasticity3);
        bedMachine[3].GetComponent<BedMachineScript>().InitializeParameter(elasticity4);
        bedMachine[4].GetComponent<BedMachineScript>().InitializeParameter(elasticity5);
        bedMachine[5].GetComponent<BedMachineScript>().InitializeParameter(elasticity6);
    }

    // Update is called once per frame
    void Update()
    {
        FallenTrap.GetComponent<PressMachineHorizontal>().SetTrapHorizontal();
    }
    /// <summary>
    /// これはリアルタイムでパラメータを反映させる関数
    /// </summary>
    void SetParameterInRealTime()
    {
        FallenTrap.GetComponent<PressMachineTrapScript>().InitializeParameter(distanceToRight, distanceToLeft, rightSpeed, leftSpeed);

        bedMachine[0].GetComponent<BedMachineScript>().InitializeParameter(elasticity);
        bedMachine[1].GetComponent<BedMachineScript>().InitializeParameter(elasticity2);
        bedMachine[2].GetComponent<BedMachineScript>().InitializeParameter(elasticity3);
        bedMachine[3].GetComponent<BedMachineScript>().InitializeParameter(elasticity4);
        bedMachine[4].GetComponent<BedMachineScript>().InitializeParameter(elasticity5);
        bedMachine[5].GetComponent<BedMachineScript>().InitializeParameter(elasticity6);
    }
}
