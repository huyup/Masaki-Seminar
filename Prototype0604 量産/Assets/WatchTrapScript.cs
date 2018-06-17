using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchTrapScript : MonoBehaviour
{
    int changeCount = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //90
        if (changeCount == 0)
        {
            if (transform.eulerAngles.z >= -5 && transform.eulerAngles.z < 95)
            {
                transform.Rotate(new Vector3(0, 0, -1));
            }
            else
            {
                changeCount++;
            }
        }
        if (changeCount == 1)
        {
            if (transform.eulerAngles.z >= 265&& transform.eulerAngles.z <360)
            {
                transform.Rotate(new Vector3(0, 0, -1));
            }
            else
            {
                changeCount++;
                //changeCount=0;
            }
        }
        if (changeCount == 2)
        {
            if (transform.eulerAngles.z >= 250 && transform.eulerAngles.z < 360)
            {
                transform.Rotate(new Vector3(0, 0, 1));
            }
            else
            {
                changeCount++;
                //changeCount=0;
            }
        }
        if (changeCount == 3)
        {
            if (transform.eulerAngles.z >= -5 && transform.eulerAngles.z < 90)
            {
                transform.Rotate(new Vector3(0, 0, 1));
            }
            else
            {
                //changeCount++;
                changeCount=0;
            }
        }
        Debug.Log(transform.eulerAngles.z);
    }
}
