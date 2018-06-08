using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetResetStage6 : ResetStage
{
    Stage6Script stage6Script;
    public override void SetNowStage()
    {
        stage6Script = GameObject.Find("Stage6").GetComponent<Stage6Script>();
    }
    public override void ResetThisStage()
    {
        stage6Script.ResetStage();
    }
}
