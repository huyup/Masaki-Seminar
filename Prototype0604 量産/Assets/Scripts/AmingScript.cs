using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum NowTarget
{
    Near,
    Middle,
    Far,
    NULL,
}
public class AmingScript : MonoBehaviour
{
    GameObject player;

    GameObject target;

    GameObject target_Near;
    GameObject target_MiddleFar;
    GameObject target_Far;

    GameObject ghost1;
    GameObject ghost2;
    GameObject ghost3;

    int ghostNum;

    NowTarget nowTarget;

    public float velocityY;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        ghostNum = 0;

    }

    void Update()
    {
        FindTargetInRealTime();

        //ゴーストがない場合
        if (ghost1 == null && ghost2 == null && ghost3 == null)
        {
            ghostNum = 0;
            target = null;
        }

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

        if (ghostNum > 0)
        {
            if (ghostNum == 1)
            {
                //if (Input.GetKeyDown(KeyCode.L))
                //{
                    transform.position = (player.transform.position + target.transform.position) / 2;
                //}

            }

            if (ghostNum == 2)
            {
                //if (Input.GetKeyDown(KeyCode.L))
                //{
                //    target = target_MiddleFar;
                //}
                //if (Input.GetKey(KeyCode.L)&&target!=null)
                //{
                    transform.position = (player.transform.position + target.transform.position) / 2;
                //}
                if (Input.GetButtonDown("ChangeTarget1"))
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
                if (Input.GetButtonDown("ChangeTarget2"))
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
                //if (Input.GetKeyDown(KeyCode.L))
                //{
                    target = target_Near;
                //}
                //if (Input.GetKey(KeyCode.L))
                //{
                    transform.position = (player.transform.position + target.transform.position) / 2;
                //}
                if (Input.GetButtonDown("ChangeTarget1"))
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
                if (Input.GetButtonDown("ChangeTarget2"))
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

        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    transform.position = (player.transform.position + target_Near.transform.position) / 2;
        //}
        //if (Input.GetKey(KeyCode.L))
        //{
        //    if (Input.GetKeyDown(KeyCode.W))
        //    {
        //        transform.position = (player.transform.position + target_Middle.transform.position) / 2;
        //    }
        //    if (Input.GetKeyDown(KeyCode.S))
        //    {
        //        transform.position = (player.transform.position + target_Far.transform.position) / 2;
        //    }
        //}
        velocityY = player.GetComponent<PlayerController>().g_VeclocityY;

        transform.position += new Vector3(0, velocityY * 0.05f, 0);
    }


    /// <summary>
    /// これはリアルタイムでオブジェクトを見つける関数です
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
