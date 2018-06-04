using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollController : MonoBehaviour {
    public GameObject dollPrefab;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CreateDoll(Vector3 respawnPos)
    {
        GameObject doll = Instantiate(dollPrefab, respawnPos, new Quaternion(0, 0, 0, 0));
        doll.name = dollPrefab.name.ToString();
        doll.transform.eulerAngles = new Vector3(0, 90, 0);
    }
}
