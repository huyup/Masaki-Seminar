using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// これは罠：落石をコントロールするクラス
/// 作成者:huyup
/// </summary>
public class FallenStoneScript : MonoBehaviour
{
    int hitFloorCount;
    [HideInInspector]
    public bool fallenEnable;
    bool addForceEnable;

    float FallenVeloc { get; set; }
    float HitFloor_AddForce { get; set; }
    
    // Use this for initialization
    void Start()
    {
    }
    public void InitializeParameter(float _FallenVeloc,float _HitFloor_AddForce)
    {
        FallenVeloc = _FallenVeloc;
        HitFloor_AddForce = _HitFloor_AddForce;
    }
    // Update is called once per frame
    void Update()
    {
        if(fallenEnable)
        {
            SetFallenStone();
        }
    }
    /// <summary>
    /// これは岩を落下させるメソッド
    /// 床に落ちたら、力を与える
    /// </summary>
    public void SetFallenStone()
    {
        GetComponent<Rigidbody>().isKinematic = false;

        transform.GetComponent<Rigidbody>().AddForce(0, FallenVeloc, 0);

        if (hitFloorCount == 1 && addForceEnable)
        {
            transform.GetComponent<Rigidbody>().AddForce(HitFloor_AddForce, 0, 0, ForceMode.VelocityChange);
            addForceEnable = false;
        }
        if (hitFloorCount == 2 && addForceEnable)
        {
            transform.GetComponent<Rigidbody>().AddForce(HitFloor_AddForce, 0, 0, ForceMode.VelocityChange);
            addForceEnable = false;
            fallenEnable = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            addForceEnable = true;
            hitFloorCount++;
        }

    }
}
