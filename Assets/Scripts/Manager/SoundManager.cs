using UnityEngine;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

    public List<AudioSource> AllSound = new List<AudioSource>();
    public enum SoundIngame
    {
        FlipCard,
        MatchCard,
        MatchJoker,
        AddStar,
        OpenPopup,
        NoMatch,
        Win,
        Lose,
        Click
    }

    public void SoundOn(SoundIngame soundEnum)
    {
        if(IsOnSound())
        {
            int index = (int)soundEnum;
            if(index <= AllSound.Count)
            {
                if(!AllSound[index].isPlaying)
                {
                    AllSound[index].Play();
                }
            }
        }
    }

    public string IS_ON_MUSIC = "IS_ON_MUSIC";
    public string IS_ON_SOUND = "IS_ON_SOUND";
    public AudioSource BgMusic, ClickBtn;

    public static SoundManager instance;
    void Awake()
    {
        SoundManager.instance = this;
        SetInitData();
    }

    void Start()
    {
        IsOnMusic();
        IsOnSound();
    }

    public bool IsOnMusic()
    {
        if(PlayerPrefs.GetString(IS_ON_MUSIC) == "TRUE")
        {
            if (!BgMusic.isPlaying)
            {
                BgMusic.Play();
            }
            return true;
        }

        BgMusic.Stop();
        return false;
    }

    public bool IsOnSound()
    {
        if (PlayerPrefs.GetString(IS_ON_SOUND) == "TRUE")
        {
            return true;
        }

        return false;
    }

    private void SetInitData()
    {
        if (!PlayerPrefs.HasKey(IS_ON_MUSIC))
        {
            PlayerPrefs.SetString(IS_ON_MUSIC, "TRUE");
        }

        if (!PlayerPrefs.HasKey(IS_ON_SOUND))
        {
            PlayerPrefs.SetString(IS_ON_SOUND, "TRUE");
        }
    }

    public void SetMusic()
    {
        if (IsOnMusic())
        {
            PlayerPrefs.SetString(IS_ON_MUSIC, "FALSE");
        }
        else
        {
            PlayerPrefs.SetString(IS_ON_MUSIC, "TRUE");
        }
    }

    public void SetSound()
    {
        if (IsOnSound())
        {
            PlayerPrefs.SetString(IS_ON_SOUND, "FALSE");
        }
        else
        {
            PlayerPrefs.SetString(IS_ON_SOUND, "TRUE");
        }
    }
}
