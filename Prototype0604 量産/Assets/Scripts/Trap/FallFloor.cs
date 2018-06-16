using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// これは装置：落ちる床をコントロールするクラス
/// 作成者:huyup
/// </summary>

public class FallFloor : MonoBehaviour {
    Vector3 fallFloorInitPos;

    bool fallEnable;

    float FallenVeloc { get; set; }

	// Use this for initialization
	void Start () {
        fallFloorInitPos = transform.position;
        fallEnable = false;
	}

    public void ResetFallFloor()
    {
        gameObject.GetComponent<BoxCollider>().isTrigger = false;

        transform.position = fallFloorInitPos;

        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

        fallEnable = false;
    }
    public void InitializeParameter(float _FallenVeloc)
    {
        FallenVeloc = _FallenVeloc;
    }
    // Update is called once per frame
    void FixedUpdate () {
        MoveFallFloor();
    }

    void MoveFallFloor()
    {
        if(fallEnable)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().AddForce(0, FallenVeloc, 0, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
            fallEnable = true;
        if (collision.gameObject.name == "OutArea")
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }
}
