using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void ChangeSceneBtn()
    {
        switch (this.gameObject.name)
        {
            case "1":
                SceneManager.LoadScene("intro2");
                break;
            case "2":
                SceneManager.LoadScene("intro3");
                break;
            case "3":
                SceneManager.LoadScene("intro4");
                break;
            case "4":
                SceneManager.LoadScene("intro5");
                break;
            case "5":
                SceneManager.LoadScene("intro6");
                break;
        }
    }
}
