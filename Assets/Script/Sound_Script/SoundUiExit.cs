using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundUiExit : MonoBehaviour
{
    public GameObject SoundUI;

    public void Onclick()
    {
        SoundUI.SetActive(false);
    }
}
