using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager {
    #region field
    class AudioClipInfo
    {
        public string key;
        public string resName;
        public AudioClip audioClip;

        public AudioClipInfo(string key, string resName)
        {
            this.key = key;
            this.resName = resName;
            audioClip = Resources.Load(resName) as AudioClip;
        }
    }

    // シングルトン
    static SoundManager singleton = null;
    // インスタンス取得
    public static SoundManager GetInstance()
    {
        return singleton ?? (singleton = new SoundManager());
    }

    enum soundType
    {
        BGM, SE,
    }

    GameObject soundPlayer;
    AudioSource audioSourceBgm;
    AudioSource audioSourceSe;
    Dictionary<string, AudioClipInfo> poolBgm = new Dictionary<string, AudioClipInfo>();
    Dictionary<string, AudioClipInfo> poolSe = new Dictionary<string, AudioClipInfo>();
    #endregion

    public SoundManager()
    {
        poolBgm.Add("titleBgm", new AudioClipInfo("titleBgm", "Sound/bgm/TitleBgm"));
        poolBgm.Add("stageBgm", new AudioClipInfo("stageBgm", "Sound/bgm/StageBgm"));

        poolSe.Add("jumpSe", new AudioClipInfo("jumpSe", "Sound/se/Character/jump3"));
        poolSe.Add("walkSe", new AudioClipInfo("walkSe", "Sound/se/Character/walk4"));

        poolSe.Add("clearSe", new AudioClipInfo("clearSe", "Sound/se/Effect/Clear2"));
        poolSe.Add("doorSe", new AudioClipInfo("doorSe", "Sound/se/Effect/Door2"));
        poolSe.Add("ghostSe", new AudioClipInfo("ghostSe", "Sound/se/Effect/GhostSpawn2"));

        poolSe.Add("bedSe", new AudioClipInfo("walkSe", "Sound/se/Gimmick/BedJump"));
        poolSe.Add("pendulumSe", new AudioClipInfo("walkSe", "Sound/se/Gimmick/Pendulum"));
        poolSe.Add("pierceSe", new AudioClipInfo("walkSe", "Sound/se/Gimmick/Pierce"));
        poolSe.Add("pressSe", new AudioClipInfo("walkSe", "Sound/se/Gimmick/PressingMachine"));
        poolSe.Add("rockSe", new AudioClipInfo("walkSe", "Sound/se/Gimmick/RollingRock"));
    }

    #region bgm
    public static bool PlayBGM(string bgmName)
    {
        return GetInstance()._PlayBgm(bgmName);
    }
    bool _PlayBgm(string bgmName)
    {
        if (!poolBgm.ContainsKey(bgmName))
            return false;

        AudioClipInfo info = poolBgm[bgmName];
        if (soundPlayer == null)
        {
            soundPlayer = new GameObject("SoundPlayer");
            GameObject.DontDestroyOnLoad(soundPlayer);
            audioSourceBgm = soundPlayer.AddComponent<AudioSource>();
        }

        audioSourceBgm.loop = true;
        audioSourceBgm.clip = info.audioClip;
        audioSourceBgm.Play();

        return true;
    }

    public static bool StopBGM()
    {
        return GetInstance()._StopBgm(); 
    }

    bool _StopBgm()
    {
        audioSourceBgm.Stop();
        return true;
    }
    public static bool IsPlayingBgm()
    {
        return GetInstance()._IsPlayingBgm();
    }

    bool _IsPlayingBgm()
    {
        if (audioSourceBgm != null)
            return audioSourceBgm.isPlaying;
        return false;
    }

    public static bool PauseBgm()
    {
        return GetInstance()._PauseBgm();
    }
    bool _PauseBgm()
    {
        audioSourceBgm.Pause();
        return true;
    }

    public static bool UnPauseBgm()
    {
        return GetInstance()._UnPauseBgm();
    }
    bool _UnPauseBgm()
    {
        audioSourceBgm.UnPause();
        return true;
    }
    #endregion

    #region se
    public static bool PlaySe(string seName)
    {
        return GetInstance()._PlaySe(seName);
    }
    bool _PlaySe(string seName)
    {
        if (!poolSe.ContainsKey(seName))
            return false;

        AudioClipInfo info = poolSe[seName];
        if (soundPlayer == null)
        {
            soundPlayer = new GameObject("SoundPlayer");
            GameObject.DontDestroyOnLoad(soundPlayer);
            audioSourceSe = soundPlayer.AddComponent<AudioSource>();
            audioSourceSe.clip = info.audioClip;
        }
        if (!HasExitSound(info))
        {
            audioSourceSe = soundPlayer.AddComponent<AudioSource>();
            audioSourceSe.clip = info.audioClip;
        }

        audioSourceSe.PlayOneShot(info.audioClip, 0.5f);

        return true;
    }
    private bool HasExitSound(AudioClipInfo info)
    {
        foreach (AudioSource source in soundPlayer.GetComponents<AudioSource>())
        {
            if (info.audioClip == source.clip)
                return true;
        }

        return false;
    }
    public static bool StopSe()
    {
        return GetInstance()._StopSe();
    }

    //bool _StopSe(string seName)
    //{
    //    if (audioSourceSe == null)
    //        return false;

    //    AudioClipInfo info = poolSe[seName];
    //    foreach (AudioSource source in soundPlayer.GetComponents<AudioSource>())
    //    {
    //        if (info.audioClip == source.clip)
    //        {
    //            source.Stop();
    //            return true;
    //        }
    //    }
    //    return false;
    //}

    bool _StopSe()
    {
        if (audioSourceSe == null)
            return false;
        audioSourceSe.Stop();
        return true;
    }

    public static bool IsPlayingSe()
    {
        return GetInstance()._IsPlayingSe();
    }

    bool _IsPlayingSe()
    {
        if (audioSourceSe != null)
            return audioSourceSe.isPlaying;

        return false;
    }
    #endregion
}
