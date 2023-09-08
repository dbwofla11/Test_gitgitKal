using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToStage5 : MonoBehaviour
{
    public void NextSceneWithString()
    {
        // 문자열 이용해서 씬 전환
        SceneManager.LoadScene("Scenes/Stage5"); // OK
    }
}
