using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// これは装置：ベッドをコントロールするクラス
/// 作成者:huyup
/// </summary>
public class BedMachineScript : MonoBehaviour {
    float Elasticity { get; set; }
    GameObject player;
    // Use this for initialization
    void Start () {
		player=GameObject.Find("Player");
	}
    public void InitializeParameter(float _Elasticity)
    {
        Elasticity = _Elasticity;
    }
    // Update is called once per frame
    void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name=="Player")
        {
            if (!collision.gameObject.GetComponent<PlayerController>().isGround)
            {
                collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * Elasticity, ForceMode.VelocityChange);
            }
        }
    }
}
