using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// これはプレイヤーのライフをコントロールするクラス
/// </summary>
public class PlayerLifeControl : MonoBehaviour
{

    public int lifeCount;
    public bool invincble = false;
    GameObject Eff_Invincble;
    public const int MAXINVINCBLECOUNT = 30;
    int invincbleCount = MAXINVINCBLECOUNT;
    //Use this for initialization

    void Start()
    {
        //ライフ初期化
        lifeCount = 1;

        Eff_Invincble = GameObject.Find("Eff_PowerUp_Fix");
    }
    private void ResetLife()
    {
        lifeCount = 1;
    }
    // Update is called once per frame
    void Update()
    {

        if (lifeCount < 0)
            lifeCount = 0;

        if (invincble)
        {
            Eff_Invincble.transform.position = transform.position + new Vector3(0, 1, 0);

            if (!Eff_Invincble.transform.Find("parline1_add").GetComponent<ParticleSystem>().isPlaying)
                Eff_Invincble.transform.Find("parline1_add").GetComponent<ParticleSystem>().Play();

            if (invincbleCount > 0)
            {


                invincbleCount--;
            }
            else
            {
                if (Eff_Invincble.transform.Find("parline1_add").GetComponent<ParticleSystem>().isPlaying)
                    Eff_Invincble.transform.Find("parline1_add").GetComponent<ParticleSystem>().Stop();
                invincble = false;
                invincbleCount = MAXINVINCBLECOUNT;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!invincble)
        {
            //tag名が”トラップ”のオブジェと遭遇したら、ライフ数を減らす
            if (collision.gameObject.tag == "Trap" || collision.gameObject.layer == 10/*10:OutArea*/)
            {
                lifeCount--;
            }
            if (collision.gameObject.tag == "Stone")
            {
                if (collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 1)
                {
                    lifeCount--;
                }
            }
        }
    }
}
