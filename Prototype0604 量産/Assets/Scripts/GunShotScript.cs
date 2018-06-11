using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShotScript : MonoBehaviour
{
    public GameObject shot;
    public GameObject aming;
    GameObject shot_Clone;
    GameObject player;
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
                Vector3 newPos = aming.transform.position - transform.position + new Vector3(0, 0.1f, 0);
                Instantiate(shot, transform.position, Quaternion.identity);

                shot_Clone = GameObject.Find("shot(Clone)");
                //shot_Clone.transform.rotation = Quaternion.LookRotation(player.transform.position, aming.transform.position);

                shot_Clone.transform.LookAt(aming.transform);
                shot_Clone.transform.Rotate(0, 90, 0);

                shot_Clone.GetComponent<Rigidbody>().AddForce(newPos * 20f, ForceMode.VelocityChange);
            }
        }
    }
}
