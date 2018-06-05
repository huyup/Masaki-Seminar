using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStage : MonoBehaviour {
    static PlayerController player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent< PlayerController>();
    }
	
    public static void ResetThisStage()
    {
        player.ResetPlayer();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
