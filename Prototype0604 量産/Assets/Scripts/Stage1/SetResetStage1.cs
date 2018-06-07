using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetResetStage1 : ResetStage {
    Stage1Script stage1Script;
    public override void SetNowStage()
    {
        stage1Script = GameObject.Find("Stage1").GetComponent<Stage1Script>();
    }
    public override void ResetThisStage()
    {
        stage1Script.ResetStage();
    }
}
