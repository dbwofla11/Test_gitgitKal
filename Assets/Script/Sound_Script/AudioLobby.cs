using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioLobby : MonoBehaviour
{
    private AudioSource audio;
    private GameObject[] musics;

    float timer;
    int waitingTime;

    void Start()
    {
        timer = 0.0f;
        waitingTime = 2;
    }

    private void Update()
    {
        SceenChange();
    }


    private void Awake()
    {
        musics = GameObject.FindGameObjectsWithTag("Music");

        if (musics.Length >= 2)
        {
            Debug.Log("musics-Length : " + musics.Length);
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(transform.gameObject);
        audio = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (audio.isPlaying) return;
        audio.Play();
    }

    public void StopMusic()
    {
        audio.Stop();
    }

    public void SceenChange()
    {
        bool isEnding = SceneManager.GetActiveScene().name == "Stage1";
        if (isEnding)
        {
            Debug.Log(SceneManager.GetActiveScene().name + isEnding);
            Debug.Log("¿£µùµµÂø");
            Destroy(this.gameObject);
        }
    }
}