using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowPause :MonoBehaviour{
    PlayerController playerController;

    // Use this for initialization
    void Start() {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update () {
        UpdateInput();
    }

    void UpdateInput()
    {
        if (!playerController.P_CanControlPlayer)
            return;

        if (Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            Pauser.Pause();
        }
    }
}
