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
    // Use this for initialization
    void Start () {
		
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
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * Elasticity,ForceMode.VelocityChange);
        }
    }
}
