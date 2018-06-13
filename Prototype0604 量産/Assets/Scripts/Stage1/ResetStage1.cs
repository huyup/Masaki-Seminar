using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStage1 : MonoBehaviour{
    SetResetStage1 s1;

	// Use this for initialization
	void Start () {
        s1 = new SetResetStage1();
        s1.InitPlayer();
        s1.SetNowStage();
    }
	
	// Update is called once per frame
	void LateUpdate () {
        s1.UpdateReset();
    }
}
