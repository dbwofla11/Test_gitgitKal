using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToStage3 : MonoBehaviour
{
    public void NextSceneWithString()
    {
        // ���ڿ� �̿��ؼ� �� ��ȯ
        SceneManager.LoadScene("Scenes/Stage3"); // OK
    }
}
