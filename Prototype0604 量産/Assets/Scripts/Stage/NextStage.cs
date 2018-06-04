using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
    public int StageNum = 2;

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
        string nextStage = StageNum.ToString();
        if(SceneManager.GetSceneByName("Stage" + nextStage).IsValid())
            SceneManager.LoadScene("Stage" + nextStage);
        else
            SceneManager.LoadScene("Stage" + (StageNum-1).ToString());
    }
}
