using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetResetStage4 : ResetStage
{
    Stage4Script stage4Script;
    public override void SetNowStage()
    {
        stage4Script = GameObject.Find("Stage4").GetComponent<Stage4Script>();
    }
    public override void ResetThisStage()
    {
        stage4Script.ResetStage();
    }
}
