using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
