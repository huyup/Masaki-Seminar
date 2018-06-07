using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStage4 : MonoBehaviour
{
    SetResetStage4 s4;

    // Use this for initialization
    void Start()
    {
        s4 = new SetResetStage4();
        s4.InitPlayer();
        s4.SetNowStage();
    }

    // Update is called once per frame
    void Update()
    {
        s4.UpdateReset();
    }
}
