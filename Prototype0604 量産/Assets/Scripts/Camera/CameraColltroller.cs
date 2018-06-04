using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// これはカメラを移動するクラス
/// カメラの注目点であるターゲットが必要
/// </summary>
public class CameraColltroller : MonoBehaviour {
    public GameObject target;

//ねっぽ　カメラとプレイヤーの距離を追加した
    Vector3 cameraDis;

	// Use this for initialization
	void Start () {
        cameraDis = Camera.main.transform.position;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //カメラの位置を決める
        Camera.main.transform.position = target.transform.position + (cameraDis - target.transform.position);
	}
}
