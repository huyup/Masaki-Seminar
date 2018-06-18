using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BgmManager : MonoBehaviour {
    string oldScene;
    string nowScene;
    PlayerController playerController;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Use this for initialization
    void Start () {
        oldScene = "";
        playerController = null;
    }
	
	// Update is called once per frame
	void Update () {
        ChangeBgm();
    }

    void ChangeBgm()
    {
        nowScene = SceneManager.GetActiveScene().name;

        if(playerController != null && !playerController.P_CanControlPlayer && SoundManager.IsPlayingBgm())
            SoundManager.StopBGM();

        if (oldScene == nowScene)
            return;
        
        switch(nowScene)
        {
            case "Title":
                Title title = GameObject.Find("Canvas").GetComponent<Title>();
                if (SoundManager.IsPlayingBgm())
                    SoundManager.StopBGM();
                if (title.p_IncreaseRgbBg > 0 && !SoundManager.IsPlayingBgm())
                    SoundManager.PlayBGM("titleBgm");
                else
                    return;
                break;
            case "Menu":
            case "StageSelect":
                if (SoundManager.IsPlayingBgm())
                {
                    SoundManager.StopBGM();
                }
                SoundManager.PlayBGM("titleBgm");
                break;
            case "Loading":
                SoundManager.StopBGM();
                break;
            default:
                playerController = GameObject.Find("Player").GetComponent<PlayerController>();
                if (SoundManager.IsPlayingBgm())
                {
                    SoundManager.StopBGM();
                }
                SoundManager.PlayBGM("stageBgm");
                break;
        }

        oldScene = nowScene;
    }
}
