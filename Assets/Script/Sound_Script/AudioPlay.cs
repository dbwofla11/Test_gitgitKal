using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioPlay : MonoBehaviour
{
    private AudioSource audio;
    private GameObject[] musics;


    private void Awake()
    {
        musics = GameObject.FindGameObjectsWithTag("Music");

        if ( musics.Length >= 2)
        {
            Debug.Log("musics-Length : " + musics.Length);
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(transform.gameObject);
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        SceenChange();
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
        bool isEnding = SceneManager.GetActiveScene().name == "END";
        bool isStart = SceneManager.GetActiveScene().name == "intro6";
        if (isEnding)
        {
            Debug.Log(SceneManager.GetActiveScene().name + isEnding);
            Debug.Log("¿£µùµµÂø");
            Destroy(this.gameObject);
        }
        if (isStart)
        {
            Destroy(this.gameObject);
        }
    }


}
