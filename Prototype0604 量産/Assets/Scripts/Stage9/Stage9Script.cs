using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// これはステージ9全般をコントロールするクラス
/// 作成者:huyup
/// </summary>
public class Stage9Script : MonoBehaviour
{

    //参照
    GameObject watchMachine;
    GameObject watchMachine2;

    //パラメータ
    public static string mshinItoName = "時計";
    public float vibrationVeloc = 3;


    // Use this for initialization
    void Start()
    {
        watchMachine = GameObject.Find("huriko");
        watchMachine2 = GameObject.Find("huriko2");

        watchMachine.GetComponent<WatchTrapScript>().InitializeParameter(vibrationVeloc);
        watchMachine2.GetComponent<WatchTrapScript>().InitializeParameter(vibrationVeloc);
    }

    public void ResetStage()
    {
        watchMachine.GetComponent<WatchTrapScript>().ResetWatch();
        watchMachine2.GetComponent<WatchTrapScript>().ResetWatch();
    }

    // Update is called once per frame
    void Update()
    {
        if (UIScript.parameter_ChangeEnable)
            SetParameterInRealTime();
    }
    
    /// <summary>
    /// これはリアルタイムでパラメータを反映させる関数
    /// </summary>
    void SetParameterInRealTime()
    {
        watchMachine.GetComponent<WatchTrapScript>().InitializeParameter(vibrationVeloc);
        watchMachine2.GetComponent<WatchTrapScript>().InitializeParameter(vibrationVeloc);
    }
}
