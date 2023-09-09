using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



namespace Stage3
{
    public class PlayerMove : MonoBehaviour
    {
        public float maxSpeed;
        public float jumpPower;

        Rigidbody2D rigid;
        SpriteRenderer spriteRenderer; // 변수명 수정
        Animator anim;
        AudioSource sound;

        Vector3 startPos; // 시작 위치 저장용 변수

        bool isRespawning = false; // 리스폰 중인지 여부를 확인하는 변수
        private bool isjump = false;

        // 새로운 오브젝트 이식 ( 게임 매니저 ) 
        public Gamemanager GM;

        // 사운드 
        public AudioClip audioJump;
        public AudioClip audioAttack;
        public AudioClip audioDamaged;
        public AudioClip audioItem;
        public AudioClip audioDie;
        public AudioClip audioFinish;


        void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>(); // 변수명 수정
            anim = GetComponent<Animator>();
            startPos = transform.position;

            sound = GetComponent<AudioSource>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Scenes/Stage3");
            }


            if (Input.GetButtonUp("Horizontal"))
            {
                rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
            }
            if (Input.GetButton("Horizontal"))
            {
                spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
            }

            // animation
            if (Mathf.Abs(rigid.velocity.x) < 0.3)
            {
                anim.SetBool("isWalking", false);
            }
            else
            {
                anim.SetBool("isWalking", true);
            }


            // 점프 ( 저기 애니메이션 가져오는 것은 무한 점프를 막기 위함 )
            if (Input.GetButtonDown("Jump") && GM.playerJumpCnt > 0)
            {
                isjump = true;
                GM.playerJumpCnt--;
                anim.SetBool("isJumping", true);
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                PlaySound("jump");
            }

        }

        void FixedUpdate()
        {
            float h = Input.GetAxisRaw("Horizontal");
            rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

            if (rigid.velocity.x > maxSpeed)
            {
                rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
            }
            else if (rigid.velocity.x < maxSpeed * (-1))
            {
                rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
            }

        }



        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {///////////////////////////////
             // 몬스터의 위치와 충돌점 정보 가져오기
                Vector2 monsterPosition = collision.gameObject.transform.position;
                ContactPoint2D contact = collision.contacts[0];


                // 충돌 지점의 y 좌표가 몬스터의 y 좌표보다 크다면
                if (contact.point.y > monsterPosition.y)
                {
                    // 몬스터를 비활성화
                    collision.gameObject.SetActive(false);
                }
                else
                {
                    isRespawning = true;
                    gameObject.layer = 11;
                    Invoke("OffDamaged", 1);
                    spriteRenderer.color = new Color(1, 1, 1, 0.4f);
                    StartCoroutine(ResetSceneAfterDelay(2f));
                }


            }

            if (collision.gameObject.tag == "dietile") // 바닥과 충돌했을 때
            {
                if (!isRespawning)
                {
                    Invoke("OnDamaged", 0.1f);
                    PlaySound("die");
                    isRespawning = true;
                    gameObject.layer = 11;
                    Invoke("OffDamaged", 0.5f);
                    spriteRenderer.color = new Color(1, 1, 1, 0.4f);
                    StartCoroutine(RespawnAfterDelay(2f)); // 2초 뒤에 리스폰
                }
            }

            // 새로운 점프 로직 이식 
            if (collision.gameObject.tag == "Ground")
            {
                if (isjump)
                {
                    isjump = false;
                    GM.JumpCntUp();
                }
                Debug.Log("땅을 밝았따 !!!!");
                anim.SetBool("isJumping", false);
            }


        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Finish") // 바닥과 충돌했을 때
            {
                GM.NextSceneWithString();
            }
        }

        void OnDamaged(Vector2 targetPos)
        {
            gameObject.layer = 11;
            spriteRenderer.color = new Color(1, 1, 1, 0.4f);

            // reaction force
            int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
            rigid.AddForce(new Vector2(dirc, 1) * 7, ForceMode2D.Impulse);
            //animation
            anim.SetTrigger("doDamaged");
            Invoke("OffDamaged", 3);

        }

        void OffDamaged()
        {
            gameObject.layer = 10;
            spriteRenderer.color = new Color(1, 1, 1, 1);

        }

        IEnumerator RespawnAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            transform.position = startPos; // 시작 위치로 리스폰
            rigid.velocity = Vector2.zero; // 속도 초기화
            isRespawning = false;
        }

        private IEnumerator ResetSceneAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void PlaySound(string action)
        {
            switch (action)
            {
                case "jump":// d
                    sound.clip = audioJump;
                    break;
                case "attack":// d
                    sound.clip = audioAttack;
                    break;
                case "damaged":// d
                    sound.clip = audioDamaged;
                    break;
                case "item":// d
                    sound.clip = audioItem;
                    break;
                case "die":// d
                    sound.clip = audioDie;
                    break;
                case "finish":// d
                    sound.clip = audioFinish;
                    break;
            }
            sound.Play();

        }


    }
}