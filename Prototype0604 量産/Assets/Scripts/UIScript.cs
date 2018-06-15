using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// これはUI全般をコントロールするクラスです
/// 作成者:huyp
/// </summary>
public class UIScript : MonoBehaviour
{
    //参照
    GameObject lightOn_Button;
    GameObject retry_Button;

    GameObject worldLight;
    GameObject player;


    public bool turnLightOn;

    public static bool parameter_ChangeEnable = false;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        lightOn_Button = GameObject.Find("LightOn_Button");
        retry_Button = GameObject.Find("Retry_Button");

        worldLight = GameObject.FindGameObjectWithTag("MainLight");


        turnLightOn = false;

        lightOn_Button.SetActive(false);
        retry_Button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //turnlightonフラグを頼って、ワールドライトの輝度を調整する
        if (!turnLightOn)
        {
            worldLight.GetComponent<Light>().intensity = 0f;
            worldLight.GetComponent<Light>().color = Color.black;
        }
        else
        {
            worldLight.GetComponent<Light>().intensity = 2f;
            worldLight.GetComponent<Light>().color = Color.white;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            turnLightOn = !turnLightOn;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player.GetComponent<PlayerLifeControl>().lifeCount = 1000;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            parameter_ChangeEnable = !parameter_ChangeEnable;
        }
    }

    /// <summary>
    /// これはLIGHT ONボタンでコントロールする関数です
    /// 呼び出したら、輝度を反転させる；
    /// </summary>
    public void ChangeTheLightIndensity()
    {
        turnLightOn = !turnLightOn;
    }

    /// <summary>
    /// これはリトライボタンでコントロールする関数です
    /// 呼び出したら、プレイヤーのライフ数を減らすをゼロまで減らす；
    /// </summary>
    public void RetryFunction()
    {
        player.GetComponent<PlayerLifeControl>().lifeCount = 0;
    }
}
