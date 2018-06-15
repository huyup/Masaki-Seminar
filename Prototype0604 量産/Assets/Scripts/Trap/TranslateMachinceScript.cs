using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// これは装置：床の転送をコントロールするクラス
/// 作成者:huyup
/// </summary>
public class TranslateMachinceScript : MonoBehaviour {
    GameObject floor;
    bool setTranslateEnable = false;

    float TranslateVeloc { get; set; }
    float TopPosY { get; set; }
    float BottomPosY { get; set; }

    Vector3 initPos;
	// Use this for initialization
	void Start () {
        floor=transform.Find("TranslateFloor").gameObject;
        initPos = floor.transform.position;
	}
    public void ResetTranslateMachine()
    {
        setTranslateEnable = false;
        floor.transform.position = initPos;
    }
    public void InitializeParameter(float _TranslateVeloc,float _TopPosY,float _BottomPosY)
    {
        TranslateVeloc = _TranslateVeloc;
        TopPosY = _TopPosY;
        BottomPosY = _BottomPosY;
    }
    // Update is called once per frame
    void Update () {
        SetTwoWayTranslateFloor();

    }

    /// <summary>
    /// これは床を往復運動させるメソッド
    /// </summary>
    public void SetTwoWayTranslateFloor()
    {
        if (setTranslateEnable)
        {
            if (floor.transform.position.y < TopPosY)
            {
                floor.transform.position += new Vector3(0, TranslateVeloc, 0);
            }
            else
            {
                setTranslateEnable = !setTranslateEnable;
            }
        }
        else
        {
            if (floor.transform.position.y > BottomPosY)
            {
                floor.transform.position -= new Vector3(0, TranslateVeloc, 0);
            }
            else
            {
                setTranslateEnable = !setTranslateEnable;
            }
        }
    }
}
