using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetResetStage5 : ResetStage
{
    Stage5Script stage5Script;
    public override void SetNowStage()
    {
        stage5Script = GameObject.Find("Stage5").GetComponent<Stage5Script>();
    }
    public override void ResetThisStage()
    {
        stage5Script.ResetStage();
    }
}
