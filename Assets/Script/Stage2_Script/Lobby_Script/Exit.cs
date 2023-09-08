using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    public void Start()
    {
        // 버튼을 클릭할 때 QuitGame 메서드를 호출하도록 설정
        Button exitButton = GetComponent<Button>();
        if (exitButton != null)
        {
            Debug.Log("나가기 버튼 클릭");
            exitButton.onClick.AddListener(QuitGame);
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // 유니티 플레이 모드에서 종료
#else
        Application.Quit(); // 빌드된 게임에서 종료
#endif
    }
}