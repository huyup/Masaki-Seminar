using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// これはプレイヤーのライフをコントロールするクラス
/// </summary>
public class PlayerLifeControl : MonoBehaviour {

    public int lifeCount;

	// Use this for initialization
	void Start () {
        //ライフ初期化
        lifeCount = 1;
	}
    private void ResetLife()
    {
        lifeCount = 1;
    }
    // Update is called once per frame
    void Update () {

        if (lifeCount < 0)
            lifeCount = 0;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //tag名が”トラップ”のオブジェと遭遇したら、ライフ数を減らす
        if (collision.gameObject.tag == "Trap" || collision.gameObject.layer == 10/*10:OutArea*/)
        {
            lifeCount--;
        }
        if (collision.gameObject.tag == "Stone")
        {
            if(collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude>1)
            {
                lifeCount--;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //tag名が”トラップ”のオブジェと遭遇したら、ライフ数を減らす
        if (other.gameObject.tag == "Trap")
        {
            lifeCount--;
        }
    }
}
