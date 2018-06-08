using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetResetStage7 : ResetStage
{
    Stage7Script stage7Script;
    public override void SetNowStage()
    {
        stage7Script = GameObject.Find("Stage7").GetComponent<Stage7Script>();
    }
    public override void ResetThisStage()
    {
        stage7Script.ResetStage();
    }
}
