using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioPlay : MonoBehaviour
{
    private AudioSource Audio;
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
        Audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        SceenChange();
    }

    public void PlayMusic()
    {
        if (Audio.isPlaying) return;
        Audio.Play();
    }

    public void StopMusic()
    {
        Audio.Stop();
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
