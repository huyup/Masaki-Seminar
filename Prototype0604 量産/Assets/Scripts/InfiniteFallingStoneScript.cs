using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// これは罠：無限に落ちる岩をコントロールするクラス
/// 作成者:huyup
/// </summary>
public class InfiniteFallingStoneScript : MonoBehaviour
{
    float FallenVeloc { get; set; }
    // Use this for initialization
    void Start()
    {

    }
    public void InitializeParameter(float _FallenVeloc)
    {
        FallenVeloc = _FallenVeloc;
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name=="OutArea")
        {
            Destroy(this);
        }
    }
}
