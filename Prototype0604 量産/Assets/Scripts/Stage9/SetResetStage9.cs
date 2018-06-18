using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetResetStage9 : ResetStage {
    Stage9Script stage9Script;
    public override void SetNowStage()
    {
        stage9Script = GameObject.Find("Stage9").GetComponent<Stage9Script>();
    }
    public override void ResetThisStage()
    {
        stage9Script.ResetStage();
    }
}
