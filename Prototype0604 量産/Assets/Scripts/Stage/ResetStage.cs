using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStage{
    public PlayerLifeControl playerLife;
    public PlayerController playerController;

    public virtual void SetNowStage(){
    }
    public　virtual void ResetThisStage(){
    }

    public void InitPlayer()
    {
        playerLife = GameObject.Find("Player").GetComponent<PlayerLifeControl>();
        playerController = GameObject.Find("Player").GetComponent< PlayerController>();
    }

    private void ResetPlayer()
    {
        playerController.ResetPlayer();
    }

    public void UpdateReset()
    {
        if (playerLife.lifeCount == 0)
        {
            ResetPlayer();
            ResetThisStage();
        }
    }
}
