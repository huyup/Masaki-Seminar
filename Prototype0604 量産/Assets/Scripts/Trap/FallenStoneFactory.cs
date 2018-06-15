using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// これは装置：ミシン糸を作る装置をコントロールするクラス
/// 作成者:huyup
/// </summary>
public class FallenStoneFactory : MonoBehaviour
{
    //参照
    public GameObject fallenStone;

    //パラメータ
    float IntervalOfCreate { get; set; }
    float timeElapsed;
    // Use this for initialization
    void Start()
    {

    }

    public void ResetFallenStoneFactory()
    {
        timeElapsed = 0f;
    }

    public void InitializeParameter(float _IntervalOfCreate)
    {
        IntervalOfCreate = _IntervalOfCreate;

    }
    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= IntervalOfCreate)
        {
            CreateFallenStone();
            timeElapsed = 0;
        }
    }
    /// <summary>
    /// これは落石を生成する関数
    /// </summary>
    void CreateFallenStone()
    {
        Instantiate(fallenStone,transform.position, Quaternion.identity);
    }
}
