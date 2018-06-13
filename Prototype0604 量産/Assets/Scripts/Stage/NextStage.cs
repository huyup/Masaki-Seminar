using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
    int nextStageNum = 0;

    private void Start()
    {
        int.TryParse(SceneManager.GetActiveScene().name.Remove(0,5), out nextStageNum);
        nextStageNum++;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);
            //一秒後に実行
            Invoke("LoadNextScene", 1f);
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("Stage" + nextStageNum.ToString());
    }
}
