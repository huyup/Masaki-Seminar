using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecordPlayerPos : MonoBehaviour
{
    GameObject player;
    GameObject soulPerformance;
    Transform playerPos;
    List<Vector3> playerPosRecord;
    GhostController ghostController;
    //DollController dollController;

    int playerLife;
    int retryNumOfTime;

    bool setSoulValue = false;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        playerPos = GameObject.Find("Player").transform;
        soulPerformance = GameObject.Find("Soul");
        playerPosRecord = new List<Vector3>();
        ghostController = GameObject.FindGameObjectWithTag("Respawn").GetComponent<GhostController>();
        //dollController = GameObject.Find("dollRespawn").GetComponent<DollController>();

        retryNumOfTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameObject.Find("Player").transform;
        playerLife = GameObject.Find("Player").GetComponent<PlayerLifeControl>().lifeCount;
        

        if (playerLife <= 0)
        {
            setSoulValue = true;

            if (setSoulValue)
            {
                soulPerformance.GetComponent<DeadPerformanceScript>().SetCircleParameter(player.transform.position);
                setSoulValue = false;
            }

            retryNumOfTime++;

            //list to vector3[]
            Vector3[] playerPosTmp = new Vector3[playerPosRecord.Count];
            for (int i = 0; i < playerPosTmp.Length; i++)
                playerPosTmp[i] = playerPosRecord[i];

            //ゴーストを作る+初期化
            ghostController.InitializeGhost(playerPosTmp, retryNumOfTime);

            //人形を残す
            //dollController.CreateDoll((Vector3)playerPosRecord[playerPosRecord.Count - 1]);

            //次回のプレイのための初期化
            playerPosRecord.Clear();
        }
        else
        {
            if (player.GetComponent<PlayerController>().g_VeclocityX != 0 ||
                !player.GetComponent<PlayerController>().isGround ||
                player.GetComponent<PlayerController>().initCount > 0)
            {
                playerPosRecord.Add(playerPos.position);
            }
        }
    }
}
