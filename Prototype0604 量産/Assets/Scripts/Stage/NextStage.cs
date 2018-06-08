using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
    public int NextStageNum = 2;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            //一秒後に実行
            Invoke("LoadNextScene", 1f);
        }
    }

    void LoadNextScene()
    {
        string nextStage = NextStageNum.ToString();
        //Debug.Log(SceneManager.GetSceneByBuildIndex(-1).name);
        //if()
        SceneManager.LoadScene("Stage" + (NextStageNum).ToString());
    }
}
