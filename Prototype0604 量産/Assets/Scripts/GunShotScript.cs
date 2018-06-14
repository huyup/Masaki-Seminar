using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// これは銃をコントロールするクラスです
/// 作成者:huyp
/// </summary>
/// 
public class GunShotScript : MonoBehaviour
{
    /// <summary>
    /// 参照
    /// </summary>
    public GameObject shot;
    public GameObject aming;

    GameObject shot_Clone;
    GameObject player;

    Vector3 posToAming;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        aming = GameObject.Find("Aming");
    }

    // Update is called once per frame
    void Update()
    {
        if (aming.GetComponent<AmingScript>().isAming)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Instantiate(shot, transform.position, Quaternion.identity);
            }
        }
    }
    private void FixedUpdate()
    {
        if (GameObject.Find("shot(Clone)"))
        {
            posToAming = aming.transform.position - transform.position + new Vector3(0, 0.2f, 0);

            shot_Clone = GameObject.Find("shot(Clone)");

            shot_Clone.transform.LookAt(aming.transform);
            shot_Clone.transform.Rotate(0, 90, 0);
            
            shot_Clone.GetComponent<Rigidbody>().AddForce(posToAming * 20f, ForceMode.VelocityChange);
        }
    }
}
