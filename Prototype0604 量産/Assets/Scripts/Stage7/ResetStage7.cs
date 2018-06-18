using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStage7 : MonoBehaviour
{
    SetResetStage7 s7;

    // Use this for initialization
    void Start()
    {
        s7 = new SetResetStage7();
        s7.InitPlayer();
        s7.SetNowStage();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        s7.UpdateReset();
    }
}
