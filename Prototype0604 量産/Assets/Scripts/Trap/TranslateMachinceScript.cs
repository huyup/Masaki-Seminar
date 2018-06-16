using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// これは装置：床の転送をコントロールするクラス
/// 作成者:huyup
/// </summary>
public class TranslateMachinceScript : MonoBehaviour {
    GameObject floor;
    GameObject kassa;
    GameObject kassa2;
    bool setTranslateEnable = false;

    float TranslateVeloc { get; set; }
    float TopPosY { get; set; }
    float BottomPosY { get; set; }

    Vector3 initPos;
	// Use this for initialization
	void Start () {
        kassa = transform.Find("kassya").gameObject;
        kassa2 = transform.Find("kassya2").gameObject;
        floor =transform.Find("TranslateFloor").gameObject;
        initPos = floor.transform.localPosition;
	}
    public void ResetTranslateMachine()
    {
        setTranslateEnable = false;
        floor.transform.localPosition = initPos;
    }
    public void InitializeParameter(float _TranslateVeloc,float _TopPosY,float _BottomPosY)
    {
        TranslateVeloc = _TranslateVeloc;
        TopPosY = _TopPosY;
        BottomPosY = _BottomPosY;
    }
    // Update is called once per frame
    void FixedUpdate () {
        kassa.transform.Rotate(0, 0, 2);
        kassa2.transform.Rotate(0, 0, 2);

    }

    /// <summary>
    /// これは床を往復運動させるメソッド
    /// </summary>
    public void SetTwoWayTranslateFloor()
    {
        if (setTranslateEnable)
        {
            if (floor.transform.localPosition.x < TopPosY)
            {
                floor.transform.localPosition += new Vector3(TranslateVeloc,0 , 0);
            }
            else
            {
                setTranslateEnable = !setTranslateEnable;
            }
        }
        else
        {
            if (floor.transform.localPosition.x > BottomPosY)
            {
                floor.transform.localPosition -= new Vector3(TranslateVeloc,0, 0);
            }
            else
            {
                setTranslateEnable = !setTranslateEnable;
            }
        }
    }

    /// <summary>
    /// これは床を往復運動させるメソッド
    /// </summary>
    public void SetTwoWayTranslateFloor_Y()
    {
        if (setTranslateEnable)
        {
            if (floor.transform.localPosition.y < TopPosY)
            {
                floor.transform.localPosition += new Vector3(0, TranslateVeloc, 0);
            }
            else
            {
                setTranslateEnable = !setTranslateEnable;
            }
        }
        else
        {
            if (floor.transform.localPosition.y > BottomPosY)
            {
                floor.transform.localPosition -= new Vector3(0, TranslateVeloc, 0);
            }
            else
            {
                setTranslateEnable = !setTranslateEnable;
            }
        }
    }
}
