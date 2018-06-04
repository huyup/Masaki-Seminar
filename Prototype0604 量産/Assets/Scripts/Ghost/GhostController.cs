using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour {
    public GameObject ghostPrefab;
    public const int ghostNumMax = 3;

    Ghost[] ghost;

    int frameCount;

	// Use this for initialization
	void Start () {

        ghost = new Ghost[ghostNumMax];
        frameCount = 0;
	}

    public void InitializeGhost(Vector3[] pos, int retryNum)
    {
        if (retryNum <= ghostNumMax)
            InstantiateGhost(retryNum);
        CreateGhost(pos, retryNum);
        ResetGhost();
        ResetFrameCount();
    }

	//ゴーストのゲームオブジェクトを作る
    private void InstantiateGhost(int retryNum)
    {
        if (retryNum <= 0)
            return;
        GameObject ghostTmp = (GameObject)Instantiate(ghostPrefab, GameObject.FindGameObjectWithTag("Respawn").transform);
        ghostTmp.name = ghostPrefab.name + retryNum.ToString();
    }

    //ゴーストの初期化
    private void CreateGhost(Vector3[] pos, int retryNum)
    {
        if (retryNum <= 0)
            return;
        retryNum = (retryNum - 1) % ghostNumMax;
        ghost[retryNum] = GameObject.Find("Ghost" + (retryNum + 1)).GetComponent<Ghost>();
        ghost[retryNum].InitGhostPos(pos);
    }

    private void ResetGhost()
    {
        for (int i = 0; i < ghostNumMax; i++)
        {
            if (ghost[i] == null)
                continue;
            ghost[i].ResetGhost();
        }
    }

    private void ResetFrameCount()
    {
        frameCount = 0;
    }

	// Update is called once per frame
	void FixedUpdate () {

        for (int i = 0; i < ghostNumMax; i++)
        {
            if (ghost[i] == null)
                continue;
            ghost[i].MoveGhost(frameCount);
        }
        frameCount++;
    }
}
