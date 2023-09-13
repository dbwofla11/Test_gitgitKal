using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SetBackSound : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider BackAudioSlider;

    public void AudioControl()
    {
        float sound = BackAudioSlider.value;
        

        if (sound == -40f)
        {
            mixer.SetFloat("Music", -80);
        }
        else
        {
            mixer.SetFloat("Music", sound);
            Debug.Log("사운드 음량 조절 변수 체크 : " + sound);
        }

    }


    
}
