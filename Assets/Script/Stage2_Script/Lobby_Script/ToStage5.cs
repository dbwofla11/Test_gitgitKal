using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToStage5 : MonoBehaviour
{
    public void NextSceneWithString()
    {
        // ���ڿ� �̿��ؼ� �� ��ȯ
        SceneManager.LoadScene("Scenes/Stage5"); // OK
    }
}
