using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStage6 : MonoBehaviour
{
    SetResetStage6 s6;

    // Use this for initialization
    void Start()
    {
        s6 = new SetResetStage6();
        s6.InitPlayer();
        s6.SetNowStage();
    }

    // Update is called once per frame
    void Update()
    {
        s6.UpdateReset();
    }
}
