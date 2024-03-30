using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    //儲存背景音樂的AudioSource Component
    public AudioSource bgMusicAudioSource;

    public void OnEnable()
    {
        //在所有Game Object中找尋Background Music
        bgMusicAudioSource = GameObject.FindGameObjectWithTag("Background Music").GetComponent<AudioSource>();

        //暫停音樂
        bgMusicAudioSource.Pause();
    }

    public void OnDisable()
    {
        //繼續音樂
        bgMusicAudioSource.UnPause();
    }
}
