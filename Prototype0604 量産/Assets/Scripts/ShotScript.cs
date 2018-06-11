using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{

    GameObject aming;
    GameObject player;
    GameObject target;

    Vector3 distanceToTarget;
    bool setTimeScale;
    // Use this for initialization
    void Start()
    {
        setTimeScale = true;
        player = GameObject.Find("Player");
        aming = GameObject.Find("Aming");
        this.target = aming.gameObject.GetComponent<AmingScript>().target;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = target.transform.position - transform.position;

        if (distanceToTarget.magnitude < 2.5f)
        {
            if (setTimeScale)
            {
                Time.timeScale = 0.1f;
                setTimeScale = false;
            }
        }
        else
        {
            Time.timeScale = 1f;
        }
        //if (this.gameObject != null)
        //{
        //    transform.localScale += new Vector3(2, 0, 0);
        //}
        Destroy
            (this.gameObject, 0.8f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Wall2" ||
            collision.gameObject.name == "Wall3")
        {
            Destroy
                (this.gameObject);
        }
        if (collision.gameObject.tag == "Ghost")
        {

            if (collision.gameObject.GetComponent<Ghost>().beTargeted &&
                collision.gameObject.GetComponent<Ghost>().canBeTarget)
            {
                Time.timeScale = 1f;
                player.transform.Find("Point light").GetComponent<Light>().intensity = 10;

                player.gameObject.GetComponent<PlayerController>().airJumpEnable = true;
                player.gameObject.GetComponent<PlayerLifeControl>().invincble = true;


                collision.gameObject.GetComponent<Ghost>().canBeTarget = false;
                GetComponent<Rigidbody>().velocity = Vector3.zero;

                aming.GetComponent<AmingScript>().ghostNum--;


                Destroy
        (this.gameObject);
                Transform ghostSoul = collision.transform.Find("shot3");
                ghostSoul.GetComponent<Renderer>().enabled = false;

                Transform ghostBody = collision.transform.Find("character_ghost").Find("root");
                foreach (Transform child in ghostBody)
                {
                    if (child.GetComponent<Renderer>())
                        child.GetComponent<Renderer>().enabled = false;
                }

                Vector3 pos;
                pos = player.transform.position;
                player.transform.position = collision.transform.position;
                collision.transform.position = pos;
            }
        }
    }
}
