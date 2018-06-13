using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    Vector3[] ghostPos;
    ChangeRotation changeRotation;

    const float lightIntensity = 10;
    const float turnOffSpeed = 0.01f;

    Vector3 preLightPos;

    /// <summary>
    /// huyup
    /// </summary>
    public bool beTargeted;
    public bool canBeTarget=true;
    public Material beTargetedMaterial;
    public Material normalMaterial;

    // Use this for initialization
    void Start()
    {
        changeRotation = new ChangeRotation();

    }

    public void InitGhostPos(Vector3[] pos)
    {
        ghostPos = pos;
        preLightPos = pos[0];
    }

    // Update is called once per frame
    void Update()
    {
        /// <summary>
        /// huyup
        /// </summary>
        if(canBeTarget)
        {
            transform.gameObject.GetComponent<CapsuleCollider>().enabled = true;
        }
        else
        {
            transform.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }
        if (beTargeted)
        {
            bool setMaterial = true;
            if (setMaterial)
            {

                Transform ghostBody = transform.Find("character_ghost").Find("root");
                foreach (Transform child in ghostBody)
                {
                    if (child.GetComponent<Renderer>())
                        child.GetComponent<Renderer>().material = beTargetedMaterial;
                }
                setMaterial = false;
            }
        }
        else { 
            bool setMaterial = true;
            if (setMaterial)
            {

                Transform ghostBody = transform.Find("character_ghost").Find("root");
                foreach (Transform child in ghostBody)
                {
                    if (child.GetComponent<Renderer>())
                        child.GetComponent<Renderer>().material = normalMaterial;
                }
                setMaterial = false;
            }
        }
    }

    public void ResetGhost()
    {
        ResetGhostMesh();
        ResetLight();
        /// <summary>
        /// huyup
        /// </summary>
        canBeTarget = true;
    }
    private void ResetGhostMesh()
    {
        foreach (SkinnedMeshRenderer mesh in this.GetComponentsInChildren<SkinnedMeshRenderer>())
            mesh.enabled = true;
        /// <summary>
        /// huyup
        /// </summary>
        //Transform ghostSoul = transform.Find("shot3");
        //ghostSoul.GetComponent<Renderer>().enabled = true;
        Transform ghostBody = transform.Find("character_ghost").Find("root");
        foreach (Transform child in ghostBody)
        {
            if (child.GetComponent<Renderer>())
                child.GetComponent<Renderer>().material = normalMaterial;
        }
    }

    private void ResetLight()
    {
        gameObject.GetComponentInChildren<Light>().intensity = lightIntensity;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("GhostLineLight"))
            Destroy(obj);
    }

    public void MoveGhost(int frameCount)
    {
        if (ghostPos.Length <= 0)
            return;

        //ライトが徐々に消える
        if (frameCount > ghostPos.Length)
        {
            TurnOffLight();
            return;
        }
        //死亡位置に着いたらゴーストのMESHを消す、エフェクト再生
        if (frameCount == ghostPos.Length)
        {
            PlayerEffect();
            foreach (SkinnedMeshRenderer mesh in this.GetComponentsInChildren<SkinnedMeshRenderer>())
                mesh.enabled = false;
            return;
        }

        //コーストを動かす
        this.transform.position = ghostPos[frameCount];

        //ゴーストの回転
        if (frameCount == 0)
            return;
        changeRotation.ChangeDirection(ghostPos[frameCount].x - ghostPos[frameCount - 1].x, this.gameObject);
    }

    public void CreateAreaLight(int frameCount, GameObject light)
    {
        if (frameCount >= ghostPos.Length)
            return;
        float disDiff = 2f;
        if (Mathf.Abs(ghostPos[frameCount].x - preLightPos.x) > disDiff)
        {
            float height = 2f;
            Vector3 instantiatePos = new Vector3(ghostPos[frameCount].x, ghostPos[frameCount].y + height, ghostPos[frameCount].z);
            Instantiate(light, instantiatePos, Quaternion.identity);
            preLightPos = ghostPos[frameCount];
        }
    }

    void TurnOffLight()
    {
        Light areaLight = gameObject.GetComponentInChildren<Light>();
        if (areaLight.intensity <= 0)
            return;
        areaLight.intensity -= turnOffSpeed;
    }

    void PlayerEffect()
    {
        ParticleSystem dieEffect = gameObject.GetComponentInChildren<ParticleSystem>();
        dieEffect.transform.position = ghostPos[ghostPos.Length - 1];
        dieEffect.Play();
    }
}
