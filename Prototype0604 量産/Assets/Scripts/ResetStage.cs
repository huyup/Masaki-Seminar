using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStage : MonoBehaviour {
    static PlayerController player;
    static StoneScript stoneScript;
    static SwitchScript switchScript;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent< PlayerController>();
        //stoneScript = GameObject.Find("Stone").GetComponent<StoneScript>();
        //switchScript = GameObject.Find("Switch").GetComponent<SwitchScript>();
    }
	
    public static void ResetThisStage()
    {
        player.ResetPlayer();
        //stoneScript.ResetStone();
        //switchScript.ResetSwitch();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
