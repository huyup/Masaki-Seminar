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

    void UnLoadStage()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        Pauser.DestoryTarget();
    }

    void LoadStage()
    {
        switch (StageSelect.getStageNum())
        {
            case StageSelect.StageNum.Stage1:
                UnLoadStage();
                SceneManager.LoadScene("Stage1", LoadSceneMode.Single);
                break;
            case StageSelect.StageNum.Stage2:
                UnLoadStage();
                SceneManager.LoadScene("Stage2", LoadSceneMode.Single);
                break;
            case StageSelect.StageNum.Stage3:
                UnLoadStage();
                SceneManager.LoadScene("Stage3");
                break;
            case StageSelect.StageNum.Stage4:
                UnLoadStage();
                SceneManager.LoadScene("Stage4");
                break;
            case StageSelect.StageNum.Stage5:
                UnLoadStage();
                SceneManager.LoadScene("Stage5");
                break;
            case StageSelect.StageNum.Stage6:
                UnLoadStage();
                SceneManager.LoadScene("Stage6");
                break;
            case StageSelect.StageNum.Stage7:
                UnLoadStage();
                SceneManager.LoadScene("Stage7");
                break;
            case StageSelect.StageNum.Stage8:
                UnLoadStage();
                SceneManager.LoadScene("Stage8");
                break;
            case StageSelect.StageNum.Stage9:
                UnLoadStage();
                SceneManager.LoadScene("Stage9");
                break;
            case StageSelect.StageNum.Stage10:
                UnLoadStage();
                SceneManager.LoadScene("Stage10");
                break;
        }
    }
}
