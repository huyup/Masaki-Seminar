using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {
    Vector3[] ghostPos;
    ChangeRotation changeRotation;
    const float lightIntensity = 10;

    const float turnOffSpeed = 0.05f;

    // Use this for initialization
    void Start () {
        changeRotation = new ChangeRotation();
    }

    public void InitGhostPos(Vector3[] pos)
    {
        ghostPos = pos;
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void ResetGhost()
    {
        ResetGhostMesh();
        ResetLight();
    }
    private void ResetGhostMesh()
    {
        foreach (SkinnedMeshRenderer mesh in this.GetComponentsInChildren<SkinnedMeshRenderer>())
            mesh.enabled = true;
    }

    private void ResetLight()
    {
        gameObject.GetComponentInChildren<Light>().intensity = lightIntensity;
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
