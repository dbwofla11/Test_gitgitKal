using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLobby : MonoBehaviour
{
    public void NextSceneWithString()
    {
        // ���ڿ� �̿��ؼ� �� ��ȯw
        SceneManager.LoadScene("Scenes/intro/intro6"); // OK
    }

}
