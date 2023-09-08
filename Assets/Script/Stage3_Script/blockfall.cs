using UnityEngine;

public class Blockfall : MonoBehaviour
{
    private bool isPlayerOnBlock = false; // 플레이어가 블럭 위에 있는지 여부를 확인하는 변수
    private bool isActivated = false; // 블럭이 활성화되었는지 여부를 확인하는 변수
    private float activationTime = 3f; // 블럭이 활성화된 시간을 저장하는 변수

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isActivated)
        {
            isPlayerOnBlock = true; // 플레이어가 블럭 위에 있음을 표시
            isActivated = true; // 블럭 활성화 표시
            activationTime = Time.time; // 현재 시간 저장
        }
    }

    private void Update()
    {
        if (isPlayerOnBlock && isActivated && Time.time - activationTime >= 3f)
        {
            gameObject.SetActive(false); // 3초 후에 블럭을 비활성화하여 없앰
        }
    }
}