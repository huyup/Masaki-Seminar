using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStage9 : MonoBehaviour
{
    SetResetStage9 s9;

    // Use this for initialization
    void Start()
    {
        s9 = new SetResetStage9();
        s9.InitPlayer();
        s9.SetNowStage();
    }

    // Update is called once per frame
    void Update()
    {
        s9.UpdateReset();
    }


}
