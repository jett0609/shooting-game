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
        // ���o���֪���
        timer = sound.length;

        // �����ִ����d�ɤ��|�Q����
        DontDestroyOnLoad(this.gameObject);
    }


    void Update()
    {
        // �ɶ��첾������
        timer = timer - Time.deltaTime;
        if (timer <= 0)
        {
            timer = sound.length;
            Destroy(gameObject);
        }
    }
}
