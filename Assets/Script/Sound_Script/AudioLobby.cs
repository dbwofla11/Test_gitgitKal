using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioLobby : MonoBehaviour
{
    private AudioSource Audio;
    private GameObject[] musics;


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
        Audio = GetComponent<AudioSource>();
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
        bool isEnding = SceneManager.GetActiveScene().name == "Stage1";
        if (isEnding)
        {
            Debug.Log(SceneManager.GetActiveScene().name + isEnding);
            Debug.Log("¿£µùµµÂø");
            Destroy(this.gameObject);
        }
    }
}