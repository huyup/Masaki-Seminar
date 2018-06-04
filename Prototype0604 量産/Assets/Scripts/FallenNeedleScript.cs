﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// これは落ちる針をコントロールするクラスです
/// </summary>
public class FallenNeedleScript : MonoBehaviour
{
    [HideInInspector]
    public bool trapEnable;
    [HideInInspector]
    public bool ghostTrapVisible;

    // Use this for initialization
    void Start()
    {
        if (tag == "GhostTrap")
        {
           // ghostTrapVisible = PlayerPrefsX.GetBool("ghostTrapVisible");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //落下させる
        if (trapEnable)
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().AddForce(0, -2, 0);
            trapEnable = false;
        }
        if (tag == "GhostTrap")
        {
            if (ghostTrapVisible)
            {
                GetComponent<Renderer>().enabled = true;
            }
            else
            {
                GetComponent<Renderer>().enabled = false;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //ghostTrapVisible = true;
            //PlayerPrefsX.SetBool("ghostTrapVisible", ghostTrapVisible);
        }
        if (collision.gameObject.name == "Ghost")
        {
            if (tag == "GhostTrap")
            {
                ghostTrapVisible = false;
                //PlayerPrefsX.SetBool("ghostTrapVisible", ghostTrapVisible);
            }

        }
    }
}
