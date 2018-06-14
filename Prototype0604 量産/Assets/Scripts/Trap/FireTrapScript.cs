using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// これは罠：噴火装置をコントロールするクラス
/// 作成者:huyup
/// </summary>
public class FireTrapScript : MonoBehaviour
{
    ParticleSystem fireEff;
    bool fireEnable;

    public int EruptionCount { get; private set; }

    int fireCount;
    int stopFireCount;
    // Use this for initialization
    void Start()
    {
        fireEff = transform.Find("Eff_Fire").GetComponent<ParticleSystem>();
        fireCount = 0;
        stopFireCount = 0;
        fireEnable = true;

    }
    public void InitializeParameter(int _EruptionCount)
    {
        EruptionCount = _EruptionCount;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.name +":"+ fireCount);
    }
    public void SetFireTrap()
    {
        if (fireEnable)
        {
            fireCount++;

            if (!fireEff.isPlaying)
                fireEff.Play();

            if (fireCount == EruptionCount)
            {
                fireEnable = false;
                GetComponent<BoxCollider>().enabled = false;
                stopFireCount = 0;
            }

        }
        else
        {

            stopFireCount++;

            if (!fireEff.isStopped)
                fireEff.Stop();

            if (stopFireCount == EruptionCount * 2)
            {
                GetComponent<BoxCollider>().enabled = true;
                fireEnable = true;
                fireCount = 0;
            }
        }
    }
}
