using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    public void Start()
    {
        // ��ư�� Ŭ���� �� QuitGame �޼��带 ȣ���ϵ��� ����
        Button exitButton = GetComponent<Button>();
        if (exitButton != null)
        {
            Debug.Log("������ ��ư Ŭ��");
            exitButton.onClick.AddListener(QuitGame);
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // ����Ƽ �÷��� ��忡�� ����
#else
        Application.Quit(); // ����� ���ӿ��� ����
#endif
    }
}