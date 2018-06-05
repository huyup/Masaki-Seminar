using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// これは罠：落ちる針をコントロールするクラス
/// 作成者:huyup
/// </summary>
public class FallenNeedleScript : MonoBehaviour
{
    [HideInInspector]
    public bool fallenEnable;

    float Fallen_Veloc{ get; set;}


    // Use this for initialization
    void Start()
    {
    }

    public void InitializeParameter(float _Fallen_Veloc)
    {
        Fallen_Veloc = _Fallen_Veloc;
    }

    // Update is called once per frame
    void Update()
    {
        if (fallenEnable)
        {
            SetNeedleFallen();
        }
    }

    public void SetNeedleFallen()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().AddForce(0, Fallen_Veloc, 0,ForceMode.VelocityChange);
        fallenEnable = false;
    }
}
