using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Music : MonoBehaviour
{
    public AudioSource BKMusic = null;
    private float timer;
    public AudioClip sound;
    // public AudioClip[] MusicTracks = null;

    void Start()
    {
        // 取得音樂長度
        timer = sound.length;

        // 讓音樂換關卡時不會被移除
        DontDestroyOnLoad(this.gameObject);
    }


    void Update()
    {
        // 時間到移除音樂
        timer = timer - Time.deltaTime;
        if (timer <= 0)
        {
            timer = sound.length;
            Destroy(gameObject);
        }
    }
}
