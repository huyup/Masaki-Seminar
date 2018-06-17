using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// これは弾をコントロールするクラスです
/// 作成者:huyp
/// </summary>
public class ShotScript : MonoBehaviour
{
    //参照
    GameObject aming;
    GameObject player;
    GameObject ghost;
    
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        aming = GameObject.Find("Aming");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Ghost1"))
            ghost = GameObject.Find("Ghost1");
        Destroy
            (this.gameObject, 1.5f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ghost")
        {
            if (collision.gameObject.GetComponent<Ghost>().beTargeted &&
                collision.gameObject.GetComponent<Ghost>().canBeTarget)
            {
                //ゴーストとプレイヤーの位置を入れ替わる
                Vector3 temp_Pos;
                temp_Pos = player.transform.position;
                player.transform.position = collision.transform.position;
                collision.transform.position = temp_Pos;


                //ライトを明るくする
                player.transform.Find("Point light").GetComponent<Light>().intensity = 10;

                //プレイヤーに無敵と空中ジャンプさせる
                player.gameObject.GetComponent<PlayerController>().airJumpEnable = true;
                //player.gameObject.GetComponent<PlayerLifeControl>().invincble = true;


                collision.gameObject.GetComponent<Ghost>().canBeTarget = false;
                aming.GetComponent<AmingScript>().ghostNum--;


                Destroy
        (this.gameObject);

                Transform ghostBody = collision.transform.Find("character_ghost").Find("root");

                foreach (Transform child in ghostBody)
                {
                    if (child.GetComponent<Renderer>())
                        child.GetComponent<Renderer>().enabled = false;
                }


            }
        }
    }
}
