using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public  Toggle toggle;
    public Slider volume;
    [SerializeField]
    private AudioSource BGM;
    

    public void Awake()
    {
        // 1 判断 PlayerPrefs 是否有一个缓存了的 key 为 music 的值存在。如果没有，新建一个键值对，用 music 作为键，1 作为值。
        //同时将开关设置为 on，并打开 AudioSource。这应当是玩家第一次运行游戏。值为 1 是因为不允许保存 Boolean 值
        if (!PlayerPrefs.HasKey("music"))
        {
            PlayerPrefs.SetInt("music", 1);
            toggle.isOn = true;
            BGM.enabled = true;
            PlayerPrefs.Save();
        }
        // 2检查 PlayerPrefs 中的 music 键。
        else
        {
            if (PlayerPrefs.GetInt("music") == 0)
            {
                BGM.enabled = false;
                toggle.isOn = false;
            }
            else
            {
                BGM.enabled = true;
                toggle.isOn = true;
            }
        }

        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1f);
            volume.value = 1f;
            BGM.volume = 1f;
            PlayerPrefs.Save();
        }
        else
        {
            float  savedVolume=  PlayerPrefs.GetFloat("volume");
            volume.value = savedVolume;
            BGM.volume = savedVolume;
        }
        PlayerPrefs.Save();
    }


    public void OnMusicToggle()
    {
        if (toggle.isOn)
        {
            PlayerPrefs.SetInt("music", 1);
            BGM.enabled = true;
        }
        else
        {
            PlayerPrefs.SetInt("music", 0);
            BGM.enabled = false;
        }
        PlayerPrefs.Save();
    }

    public void OnVolumeSlider()
    {
        float vs = volume.value;
        PlayerPrefs.SetFloat("volume",vs);
        BGM.volume = vs;
        PlayerPrefs.Save();
    }

}
