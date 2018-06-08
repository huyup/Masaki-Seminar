using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage5Script : MonoBehaviour
{
    //参照
    const int bedMachine_Count = 10;
    GameObject[] bedMachine = new GameObject[bedMachine_Count];

    //パラメータ
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

    public static string bedMachineName7 = "ベッド７";
    public float elasticity7 = 3;

    public static string bedMachineName8 = "ベッド８";
    public float elasticity8 = 3;

    public static string bedMachineName9 = "ベッド９";
    public float elasticity9 = 3;

    public static string bedMachineName10 = "ベッド１０";
    public float elasticity10 = 3;

    public void ResetStage()
    {
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
        bedMachine[3].GetComponent<BedMachineScript>().InitializeParameter(elasticity4);
        bedMachine[4].GetComponent<BedMachineScript>().InitializeParameter(elasticity5);
        bedMachine[5].GetComponent<BedMachineScript>().InitializeParameter(elasticity6);
        bedMachine[6].GetComponent<BedMachineScript>().InitializeParameter(elasticity7);
        bedMachine[7].GetComponent<BedMachineScript>().InitializeParameter(elasticity8);
        bedMachine[8].GetComponent<BedMachineScript>().InitializeParameter(elasticity9);
        bedMachine[9].GetComponent<BedMachineScript>().InitializeParameter(elasticity10);
    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// これはリアルタイムでパラメータを反映させる関数
    /// </summary>
    void SetParameterInRealTime()
    {
        bedMachine[0].GetComponent<BedMachineScript>().InitializeParameter(elasticity);
        bedMachine[1].GetComponent<BedMachineScript>().InitializeParameter(elasticity2);
        bedMachine[2].GetComponent<BedMachineScript>().InitializeParameter(elasticity3);
        bedMachine[3].GetComponent<BedMachineScript>().InitializeParameter(elasticity4);
        bedMachine[4].GetComponent<BedMachineScript>().InitializeParameter(elasticity5);
        bedMachine[5].GetComponent<BedMachineScript>().InitializeParameter(elasticity6);
        bedMachine[6].GetComponent<BedMachineScript>().InitializeParameter(elasticity7);
        bedMachine[7].GetComponent<BedMachineScript>().InitializeParameter(elasticity8);
        bedMachine[8].GetComponent<BedMachineScript>().InitializeParameter(elasticity9);
        bedMachine[9].GetComponent<BedMachineScript>().InitializeParameter(elasticity10);
    }
}
