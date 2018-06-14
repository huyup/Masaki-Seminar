using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// これは照準をコントロールするクラスです
/// 作成者:huyp
/// </summary>
public class AmingScript : MonoBehaviour
{
    //参照
    GameObject player;
    GameObject ghost;
    public GameObject target;

    //変数
    public int ghostNum;
    public bool isAming;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");

        ghostNum = 0;

        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<Renderer>().enabled = false;
        }
    }

    void Update()
    {
        FindTargetInRealTime();

        SetWhichGhostCanBeTarget();

        GetTargetName();
        if (Input.GetButtonDown("Aming")&&ghostNum>0)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.GetComponent<Renderer>().enabled = true;
            }
            isAming = true;
        }
        if (Input.GetButtonUp("Aming") && ghostNum > 0)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.GetComponent<Renderer>().enabled = false;
            }
            isAming = false;
        }


        if (ghostNum > 0)
        {
            if(ghostNum==1)
            {
                transform.position = (player.transform.position + target.transform.position) / 2 + new Vector3(0, 0.4f, 0);
            }
        }

    }
    void SetWhichGhostCanBeTarget()
    {
        //ゴーストが一体しかいない場合
        if (ghost != null)
        {
            ghostNum = 1;
            target = ghost;
        }
    }

    /// <summary>
    /// これはリアルタイムでターゲットを見つける関数です
    /// </summary>
    void FindTargetInRealTime()
    {
        if (GameObject.Find("Ghost1"))
            ghost = GameObject.Find("Ghost1");

    }
    void GetTargetName()
    {
        if (ghostNum > 0&&isAming)
        {
            if (target == ghost)
            {
                ghost.GetComponent<Ghost>().beTargeted = true;
            }
        }
        if (ghostNum > 0 && !isAming)
        {
            if (target == ghost)
            {
                ghost.GetComponent<Ghost>().beTargeted = false;
            }
        }
    }
}
