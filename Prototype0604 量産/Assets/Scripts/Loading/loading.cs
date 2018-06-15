using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public GameObject loadingUI;

    float waitSecond = 2f;
    //private AsyncOperation async;

    // Use this for initialization
    private void Start()
    {
        loadingUI.SetActive(true);
        Invoke("LoadStage", waitSecond);
    }

    void LoadStage()
    {
        switch (StageSelect.getStageNum())
        {
            case StageSelect.StageNum.Stage1:
                SceneManager.LoadScene("Stage1");
                break;
            case StageSelect.StageNum.Stage2:
                SceneManager.LoadScene("Stage2");
                break;
            case StageSelect.StageNum.Stage3:
                SceneManager.LoadScene("Stage3");
                break;
            case StageSelect.StageNum.Stage4:
                SceneManager.LoadScene("Stage4");
                break;
            case StageSelect.StageNum.Stage5:
                SceneManager.LoadScene("Stage5");
                break;
            case StageSelect.StageNum.Stage6:
                SceneManager.LoadScene("Stage6");
                break;
            case StageSelect.StageNum.Stage7:
                SceneManager.LoadScene("Stage7");
                break;
            case StageSelect.StageNum.Stage8:
                SceneManager.LoadScene("Stage8");
                break;
            case StageSelect.StageNum.Stage9:
                SceneManager.LoadScene("Stage9");
                break;
            case StageSelect.StageNum.Stage10:
                SceneManager.LoadScene("Stage10");
                break;
        }
    }
}
