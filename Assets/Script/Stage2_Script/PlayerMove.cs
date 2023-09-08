using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Stage2;
namespace Stage2
{
    public class PlayerMove : MonoBehaviour
    {

        public float maxSpeed;
        public float JumpPower;
        private bool isjump = false;

        Rigidbody2D rigid;
        SpriteRenderer spriteRenderer;
        Animator animator;
        BoxCollider2D Boxcollider;
        AudioSource sound;

        public GameManager GM;
        public AudioClip audioJump;
        public AudioClip audioAttack;
        public AudioClip audioDamaged;
        public AudioClip audioItem;
        public AudioClip audioDie;
        public AudioClip audioFinish;


        // Start is called before the first frame update
        private void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
            Boxcollider = GetComponent<BoxCollider2D>();
            sound = GetComponent<AudioSource>();
        }

        public void Update()
        {
            if (Input.GetButtonUp("Horizontal"))
            {
                rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
                animator.SetBool("isWalking", false);
            }

            // 방향 전환 
            if (Input.GetButton("Horizontal"))
            {
                spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1; // bool 형이니 왼쪽으로 갈때 방향 봄 
                animator.SetBool("isWalking", true);
            }

            // 점프 ( 저기 애니메이션 가져오는 것은 무한 점프를 막기 위함 )
            if (Input.GetButtonDown("Jump") && GM.playerJumpCnt > 0)
            {
                isjump = true;
                GM.playerJumpCnt--;
                animator.SetBool("isJumping", true);
                rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
                PlaySound("jump");
            }


        }


        // Update is called once per frame
        public void FixedUpdate()
        {
            move();
        }

        private void move()
        {
            Vector3 moveV = Vector3.zero;

            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                moveV = Vector3.left;
            }
            else if (Input.GetAxisRaw("Horizontal") > 0)
            {
                moveV = Vector3.right;
            }

            transform.position += moveV * maxSpeed * Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {


            if (collision.gameObject.tag == "item")
            {
                // point 
                bool isBronze = collision.gameObject.name.Contains("Bronze");
                bool isGold = collision.gameObject.name.Contains("Gold");
                // 더불점프 아이템 
                bool isDoubleJump = collision.gameObject.name.Contains("double");

                if (isBronze)
                {
                    GM.stagepoint += 100;
                    PlaySound("item");
                }
                else if (isGold)
                {
                    GM.stagepoint += 300;
                    PlaySound("item");
                }
                else if (isDoubleJump)
                {
                    GM.JumpCntUp();
                }
                collision.gameObject.SetActive(false);
            }
            else if (collision.gameObject.tag == "Finish")
            {
                // 다음으로 넘어가기 
                if (GM.stagepoint >= 3000)
                { 
                    GM.NextStage(); // 나중에 개발 
                    PlaySound("finish");
                    GM.NextSceneWithString();  
                }
                else
                {
                    GM.HPDown();
                    Debug.Log("점수가 너무 낮아여!!~~");
                }
            }
            else if (collision.gameObject.tag == "mine")
            {
                Debug.Log("지뢰밟음");
                GM.IsTraped = true;  
            }
            else if (collision.gameObject.tag == "keymine")
            {
                Debug.Log("지뢰밟음222");
                GM.IsKeyTraped = true; 
            }
        }


        private void OnCollisionEnter2D(Collision2D collision) // 몬스터 collision 
        {
            if (collision.gameObject.tag == "moster")
            {
                if (rigid.velocity.y < 0 && transform.position.y > collision.transform.position.y)
                {
                    OnAttack(collision.transform);
                }
                else
                {
                    OnDamaged(collision.transform.position);
                    GM.IsTraped = false;
                }
            }

            if (collision.gameObject.tag == "Enemy")
            {
                OnDamaged(collision.transform.position);
            }

            if (collision.gameObject.tag == "Ground")
            {
                if (isjump)
                {
                    isjump = false;
                    GM.JumpCntUp();
                }
                Debug.Log("땅을 밝았따 !!!!");
                animator.SetBool("isJumping", false);
            }

        }

        private void OnAttack(Transform enemy)
        {
            GM.stagepoint += 100;
            rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            PlaySound("attack");
            MonsterMove monsterMove = enemy.GetComponent<MonsterMove>();
            monsterMove.OnDamaged();

        }

        private void OnDamaged(Vector2 targetPos)
        {
            GM.HPDown();

            // 플레이어가 피격되었을때 
            gameObject.layer = 11;
            spriteRenderer.color = new Color(1, 1, 1, 0.4f);

            int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
            rigid.AddForce(new Vector2(dirc, 1) * 7, ForceMode2D.Impulse);

            PlaySound("damaged");
            animator.SetTrigger("doDamaged");
            Invoke("OffDamaged", 2);
        }

        private void OffDamaged()
        {
            gameObject.layer = 8;
            spriteRenderer.color = new Color(1, 1, 1, 1);
        }

        public void OnDie()
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.4f);
            spriteRenderer.flipY = true;

            Boxcollider.enabled = false;
            rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            PlaySound("die");
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
