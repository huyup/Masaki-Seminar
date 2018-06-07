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

    GameObject stoneFactory;
    GameObject stoneFactory2;
    //パラメータ
    public static string bedMachineName = "ベッド１";
    public float elasticity = 3;

    public static string bedMachineName2 = "ベッド２";
    public float elasticity2 = 3;

    public static string bedMachineName3 = "ベッド３";
    public float elasticity3 = 3;

    public static string stoneFactoryName = "落石工場";
    public float intervalOfCreate = 3;

    public static string stoneFactoryName2 = "落石工場2";
    public float intervalOfCreate2 = 3;

    public void ResetStage()
    {
        stoneFactory.GetComponent<FallenStoneFactory>().ResetFallenStoneFactory();
        stoneFactory2.GetComponent<FallenStoneFactory>().ResetFallenStoneFactory();

        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Trap"))
        {
            obj.GetComponent<InfiniteFallingStoneScript>().ResetInfiniteFallingStone();
        }
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


        stoneFactory = GameObject.Find("FallenStoneFactory");
        stoneFactory.GetComponent<FallenStoneFactory>().InitializeParameter(intervalOfCreate);

        stoneFactory2 = GameObject.Find("FallenStoneFactory2");
        stoneFactory2.GetComponent<FallenStoneFactory>().InitializeParameter(intervalOfCreate2);
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
    }
}
