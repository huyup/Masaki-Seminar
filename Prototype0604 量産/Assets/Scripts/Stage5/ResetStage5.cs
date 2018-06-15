using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStage5 : MonoBehaviour
{
    SetResetStage5 s5;

    // Use this for initialization
    void Start()
    {
        s5 = new SetResetStage5();
        s5.InitPlayer();
        s5.SetNowStage();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        s5.UpdateReset();
    }
}
