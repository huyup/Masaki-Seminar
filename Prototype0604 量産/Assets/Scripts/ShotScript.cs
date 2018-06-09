using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour {
    bool hitEnable;
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        //if (this.gameObject != null)
        //{
        //    transform.localScale += new Vector3(2, 0, 0);
        //}
        Destroy
            (this.gameObject,0.5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name=="Wall2"||
            collision.gameObject.name == "Wall3")
        {
            Destroy
                (this.gameObject);
        }
        if (collision.gameObject.tag=="Ghost")
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            hitEnable = true;

            Destroy
    (this.gameObject);

            Destroy(collision.gameObject);

            Vector3 pos;
            pos = player.transform.position;
            player.transform.position = collision.transform.position;
            collision.transform.position = pos;
        }
    }
}
