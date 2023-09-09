using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundUIOpen : MonoBehaviour
{
    public GameObject SoundUI;

    public void Onclick()
    {
        SoundUI.SetActive(true);
    }
}
