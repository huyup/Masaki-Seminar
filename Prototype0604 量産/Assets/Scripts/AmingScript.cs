using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AmingScript : MonoBehaviour
{
    //参照
    GameObject player;

    public GameObject target;

    GameObject target_Near;
    GameObject target_MiddleFar;
    GameObject target_Far;

    GameObject ghost1;
    GameObject ghost2;
    GameObject ghost3;

    //変数
    public int ghostNum;
    public bool isAming;
    
    public float velocityY;

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
            SetWhichGhostCanBeTarget();
            foreach (Transform child in transform)
            {
                child.gameObject.GetComponent<Renderer>().enabled = true;
            }
            if(ghostNum==2)
            {
                target = target_MiddleFar;
            }
            if (ghostNum == 3)
            {
                target = target_Near;
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
                transform.position = (player.transform.position + target.transform.position) / 2;
            }
            if (ghostNum == 2)
            {
                transform.position = (player.transform.position + target.transform.position) / 2;
                if (Input.GetButtonDown("ChangeTarget"))
                {
                    bool chooseEnable = true;
                    if (target == target_Far && chooseEnable)
                    {
                        target = target_MiddleFar;
                        chooseEnable = false;
                    }
                    if (target == target_MiddleFar && chooseEnable)
                    {
                        target = target_Far;
                        chooseEnable = false;
                    }
                }
            }
            if (ghostNum == 3)
            {

                transform.position = (player.transform.position + target.transform.position) / 2;
                if (Input.GetButtonDown("ChangeTarget"))
                {
                    bool chooseEnable = true;
                    if (target == target_Near && chooseEnable)
                    {
                        target = target_MiddleFar;
                        chooseEnable = false;
                    }
                    if (target == target_MiddleFar && chooseEnable)
                    {
                        target = target_Far;
                        chooseEnable = false;
                    }
                    if (target == target_Far && chooseEnable)
                    {
                        target = target_Near;
                        chooseEnable = false;
                    }
                }
            }
        }

        //velocityY = player.GetComponent<PlayerController>().g_VeclocityY;

        //transform.position += new Vector3(0, velocityY * 0.05f, 0);
    }
    void SetWhichGhostCanBeTarget()
    {
        //ゴーストが一体しかいない場合
        if (ghost1 != null && ghost2 == null && ghost3 == null)
        {
            ghostNum = 1;
            target = ghost1;
        }
        if (ghost1 == null && ghost2 != null && ghost3 == null)
        {
            ghostNum = 1;
            target = ghost2;
        }
        if (ghost1 == null && ghost2 == null && ghost3 != null)
        {
            ghostNum = 1;
            target = ghost3;
        }

        //ゴーストが二体いる場合
        if (ghost1 != null && ghost2 != null && ghost3 == null)
        {
            ghostNum = 2;
            SetAllTarget(ghost1, ghost2);
        }
        if (ghost1 == null && ghost2 != null && ghost3 != null)
        {
            ghostNum = 2;
            SetAllTarget(ghost2, ghost3);
        }
        if (ghost1 != null && ghost2 == null && ghost3 != null)
        {
            ghostNum = 2;
            SetAllTarget(ghost1, ghost3);
        }

        //ゴーストが三体いる場合
        if (ghost1 != null && ghost2 != null && ghost3 != null)
        {
            ghostNum = 3;
            SetAllTarget(ghost1, ghost2, ghost3);
        }
    }

    /// <summary>
    /// これはリアルタイムでターゲットを見つける関数です
    /// </summary>
    void FindTargetInRealTime()
    {

        if (GameObject.Find("Ghost1"))
            ghost1 = GameObject.Find("Ghost1");

        if (GameObject.Find("Ghost2"))
            ghost2 = GameObject.Find("Ghost2");

        if (GameObject.Find("Ghost3"))
            ghost3 = GameObject.Find("Ghost3");

    }
    void GetTargetName()
    {
        if (ghostNum > 0&&isAming)
        {
            if (target == ghost1)
            {
                Debug.Log("Ghost1");
                ghost1.GetComponent<Ghost>().beTargeted = true;
                if (GameObject.Find("Ghost2"))
                    ghost2.GetComponent<Ghost>().beTargeted = false;
                if (GameObject.Find("Ghost3"))
                    ghost3.GetComponent<Ghost>().beTargeted = false;
            }
            if (target == ghost2)
            {
                Debug.Log("Ghost2");
                if (GameObject.Find("Ghost1"))
                    ghost1.GetComponent<Ghost>().beTargeted = false;
                ghost2.GetComponent<Ghost>().beTargeted = true;
                if (GameObject.Find("Ghost3"))
                    ghost3.GetComponent<Ghost>().beTargeted = false;
            }
            if (target == ghost3)
            {
                Debug.Log("Ghost3");
                if (GameObject.Find("Ghost1"))
                    ghost1.GetComponent<Ghost>().beTargeted = false;
                if (GameObject.Find("Ghost2"))
                    ghost2.GetComponent<Ghost>().beTargeted = false;
                ghost3.GetComponent<Ghost>().beTargeted = true;
            }
        }
        if (ghostNum > 0 && !isAming)
        {
            if (target == ghost1)
            {
                ghost1.GetComponent<Ghost>().beTargeted = false;
            }
            if (target == ghost2)
            {
                ghost2.GetComponent<Ghost>().beTargeted = false;
            }
            if (target == ghost3)
            {
                ghost3.GetComponent<Ghost>().beTargeted = false;
            }
        }
    }
    /// <summary>
    /// これは距離順ターゲットをセット関数です
    /// 近いターゲットはtarget_MiddleFar
    /// 次の近いターゲットはtarget_Far
    /// </summary>
    void SetAllTarget(GameObject ghost_A, GameObject ghost_B)
    {
        float distance_AToPlayer;
        float distance_BToPlayer;

        distance_AToPlayer = (ghost_A.transform.position - player.transform.position).magnitude;
        distance_BToPlayer = (ghost_B.transform.position - player.transform.position).magnitude;

        if (distance_AToPlayer < distance_BToPlayer)
        {
            target_MiddleFar = ghost_A;
            target_Far = ghost_B;
        }
        else
        {
            target_MiddleFar = ghost_B;
            target_Far = ghost_A;
        }
    }
    /// <summary>
    /// これは距離順ターゲットをセット関数です
    /// 近いターゲットはtarget_Near
    /// 次の近いターゲットはtarget_MiddleFar
    /// 遠いターゲットはtarget_Farになる
    /// </summary>
    void SetAllTarget(GameObject ghost_A, GameObject ghost_B, GameObject ghost_C)
    {
        float distance_AToPlayer;
        float distance_BToPlayer;
        float distance_CToPlayer;


        distance_AToPlayer = (ghost_A.transform.position - player.transform.position).magnitude;
        distance_BToPlayer = (ghost_B.transform.position - player.transform.position).magnitude;
        distance_CToPlayer = (ghost_C.transform.position - player.transform.position).magnitude;

        float mostNearDistance = distance_AToPlayer;


        if (mostNearDistance > distance_BToPlayer)
            mostNearDistance = distance_BToPlayer;

        if (mostNearDistance > distance_CToPlayer)
            mostNearDistance = distance_CToPlayer;


        if (mostNearDistance == distance_AToPlayer)
        {
            target_Near = ghost_A;
            SetAllTarget(ghost_B, ghost_C);
        }
        if (mostNearDistance == distance_BToPlayer)
        {
            target_Near = ghost_B;
            SetAllTarget(ghost_A, ghost_C);
        }
        if (mostNearDistance == distance_CToPlayer)
        {
            target_Near = ghost_C;
            SetAllTarget(ghost_A, ghost_B);
        }
    }


}
