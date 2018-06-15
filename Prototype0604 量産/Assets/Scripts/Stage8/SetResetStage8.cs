using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetResetStage8 :ResetStage {

    Stage8Script stage8Script;
    public override void SetNowStage()
    {
        stage8Script = GameObject.Find("Stage8").GetComponent<Stage8Script>();
    }
    public override void ResetThisStage()
    {
        stage8Script.ResetStage();
    }
}
