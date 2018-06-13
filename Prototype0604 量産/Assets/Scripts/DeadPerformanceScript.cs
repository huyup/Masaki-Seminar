using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPerformanceScript : MonoBehaviour
{
    GameObject player_Soul;
    GameObject startTarget;
    ParticleSystem soulEff;

    // 移動速度
    public float m_moveSpeed = 2f;

    // 円の半径
    float Radius { set; get; }
    float InitX { set; get; }
    float InitY { set; get; }
    float InitZ { set; get; }

    static public bool moveEnable = false;

    void Start()
    {
        moveEnable = false;
        startTarget = GameObject.Find("Start");
        player_Soul = GameObject.Find("Soul");
        soulEff = player_Soul.transform.Find("Particle System").GetComponent<ParticleSystem>();

        soulEff.Stop();
        player_Soul.GetComponent<Renderer>().enabled = false;
    }

    void Update()
    {
        if (moveEnable)
            MoveToCircle();
    }

    public void SetCircleParameter(Vector3 deathPos)
    {
        moveEnable = true;
        if (!soulEff.isPlaying)
            soulEff.Play();
        m_moveSpeed = 2f;
        player_Soul.GetComponent<Renderer>().enabled = true;
        //InitX = (deathPos.x + startTarget.transform.position.x) / 2;
        //InitY = (deathPos.y + startTarget.transform.position.y) / 2;
        //InitZ = deathPos.z;
        //Radius = (deathPos.x - startTarget.transform.position.x) / 2;
        InitX = deathPos.x;
        InitY = deathPos.y;
        InitZ = deathPos.z;

    }

    public void MoveToCircle()
    {
        //// 経過時間の取得
        //float time = Time.time / 3;

        //if (transform.position.x < InitX)
        //    transform.position--;
        //// 円運動の座標演算
        //float x = Mathf.Sin(-time * m_moveSpeed + (Mathf.PI/2)) * Radius + InitX;
        //float y = Mathf.Cos(-time * m_moveSpeed + (Mathf.PI/2)) * Radius + InitY;
        //float z = InitZ;

            // オブジェクトに座標を代入
        transform.position = new Vector3(x, y, z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if (!soulEff.isStopped)
                soulEff.Stop();
            player_Soul.GetComponent<Renderer>().enabled = false;
            moveEnable = false;
            
            Transform body = other.transform.Find("character_motion2").Find("root");
            foreach (Transform child in body)
            {
                if (child.GetComponent<Renderer>())
                    child.GetComponent<Renderer>().enabled = true;
            }
        }
    }
}
