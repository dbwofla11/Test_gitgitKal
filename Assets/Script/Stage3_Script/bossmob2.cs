using UnityEngine;

public class bossmob2 : MonoBehaviour
{
    private Vector3 monsterInitialPosition; // 몬스터의 처음 위치
    private GameObject monster; // 몬스터 오브젝트
    private bool isPlayerRespawned = false; // 플레이어가 초기화되었는지 여부를 확인하는 변수

    public float moveSpeed = 2.0f; // 이동 속도
    public float moveDistance = 5.0f; // 이동 거리
    private int moveDirection = -1; // 이동 방향 (1: 오른쪽, -1: 왼쪽)
    private Vector3 initialPosition; // 시작 위치
    private SpriteRenderer spriteRenderer; // 스프라이트 렌더러 컴포넌트

    private void Start()
    {
        monster = GameObject.Find("ghost2"); // 몬스터 오브젝트를 찾아서 저장
        monsterInitialPosition = monster.transform.position; // 몬스터의 처음 위치 저장
        
        initialPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // 현재 위치에서 이동 속도와 이동 방향을 곱하여 이동 벡터를 계산
        Vector3 move = new Vector3(moveSpeed * moveDirection * Time.deltaTime, 0, 0);
        
        // 이동 벡터를 현재 위치에 더하여 오브젝트를 이동시킴
        transform.Translate(move);

        // 시작 위치에서 이동 거리만큼 움직였을 때 이동 방향을 반대로 변경하고 스프라이트를 반전시킴
        if (Mathf.Abs(transform.position.x - initialPosition.x) >= moveDistance)
        {
            moveDirection *= -1;
            spriteRenderer.flipX = !spriteRenderer.flipX; // 스프라이트 반전
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isPlayerRespawned)
        {
            // 플레이어가 초기화되었을 때만 몬스터 초기화
            isPlayerRespawned = true; // 플레이어 초기화 표시
            ReactivateMonster();
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            // 플레이어가 죽어서 초기화될 때도 몬스터 초기화
            ReactivateMonster();
        }
    }
    
    private void ReactivateMonster()
    {
        monster.SetActive(true); // 몬스터를 활성화하여 생성
        monster.transform.position = monsterInitialPosition; // 초기 위치로 이동
        isPlayerRespawned = false; // 초기화 상태 초기화
    }
}