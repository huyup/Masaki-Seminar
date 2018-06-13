using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecordPlayerPos : MonoBehaviour {
    Transform playerPos;
    List<Vector3> playerPosRecord;
    GhostController ghostController;
    //DollController dollController;

    int playerLife;
    int retryNumOfTime;

    // Use this for initialization
    void Start () {
        playerPos = GameObject.Find("Player").transform;
        playerPosRecord = new List<Vector3>();
        ghostController = GameObject.FindGameObjectWithTag("Respawn").GetComponent<GhostController>();
        //dollController = GameObject.Find("dollRespawn").GetComponent<DollController>();

        retryNumOfTime = 0;
    }
	
	// Update is called once per frame
	void Update () {
        playerPos = GameObject.Find("Player").transform;
        playerLife = GameObject.Find("Player").GetComponent<PlayerLifeControl>().lifeCount;

        if (playerLife == 0)
        {
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
            playerPosRecord.Add(playerPos.position);
        }
    }
}
