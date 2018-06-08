using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallFloor : MonoBehaviour {
    Vector3 fallFloorInitPos;
    bool fall;
    const float fallSpeed = -0.1f;

	// Use this for initialization
	void Start () {
        fallFloorInitPos = transform.position;
        fall = false;
	}

    public void ResetFallFloor()
    {
        gameObject.SetActive(true);
        transform.position = fallFloorInitPos;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        fall = false;
    }
	
	// Update is called once per frame
	void Update () {
        MoveFallFloor();
    }

    void MoveFallFloor()
    {
        if(fall)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().AddForce(0, fallSpeed, 0, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
            fall = true;
        if (collision.gameObject.name == "OutArea")
            gameObject.SetActive(false);
    }
}
