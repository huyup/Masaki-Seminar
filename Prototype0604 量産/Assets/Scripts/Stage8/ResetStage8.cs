using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStage8 : MonoBehaviour
{
    SetResetStage8 s8;

    // Use this for initialization
    void Start()
    {
        s8 = new SetResetStage8();
        s8.InitPlayer();
        s8.SetNowStage();
    }

    // Update is called once per frame
    void Update()
    {
        s8.UpdateReset();
    }


}
