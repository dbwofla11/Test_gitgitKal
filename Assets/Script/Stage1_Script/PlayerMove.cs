using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Stage1
{

    public class PlayerMove : MonoBehaviour
    {
        public float maxSpeed;
        public float JumpPower;
        public bool grounded;
        public bool isChasing;

        Rigidbody2D rigid;
        SpriteRenderer spriteRenderer;
        Animator animator;
        AudioSource sound;
        BoxCollider2D Boxcollider;

        public MobAi Mob;
        public GameManager GM;
        public NpcAI npc1;
        public NpcAI npc2;
        public NpcAI npc3;
        public NpcAI npc4;

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
            sound = GetComponent<AudioSource>();
            Boxcollider = GetComponent<BoxCollider2D>();
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Scenes/Stage1");
            }

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
            if (Input.GetButtonDown("Jump") && grounded)
            {

                GM.playerJumpCnt--;
                animator.SetBool("isJumping", true);
                PlaySound("jump");
                rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);

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

            if (collision.gameObject.tag == "Trap")
            {
                Mob.Chase();
                UnityEngine.Debug.Log("감지됨");
                isChasing = true;
            }
            if (collision.gameObject.tag == "NPC")
            {
                // point 
                bool isBronze = collision.gameObject.name.Contains("Bronze");
                bool isGold = collision.gameObject.name.Contains("Gold");
                bool isDoubleJump = collision.gameObject.name.Contains("double");

                PlaySound("item");
                GM.stagepoint += 500;
                GM.goastKeyNum -= 1;

                
                
                collision.gameObject.SetActive(false);
            }
            else if (collision.gameObject.tag == "Finish")
            {
                // 다음으로 넘어가기 
                if (GM.stagepoint >= 2000)
                {
                    PlaySound("finish");
                    GM.NextSceneWithString();
                    
                    UnityEngine.Debug.Log("마지막지점!!");
                }
                else
                {
                    UnityEngine.Debug.Log("점수가 너무 낮아여!!~~");
                }
            }
        }


        private void OnCollisionEnter2D(Collision2D collision) // 몬스터 collision 
        {
            if (collision.gameObject.tag == "moster")
            {
                if (rigid.velocity.y < 0 && transform.position.y > collision.transform.position.y)
                {
                    //OnAttack(collision.transform);
                }
                else
                {
                    OnDamaged(collision.transform.position);
                }
            }

            if (collision.gameObject.tag == "Enemy")
            {
                OnDamaged(collision.transform.position);
                isChasing = false;
            }

            if (collision.gameObject.tag == "Ground")
            {
                grounded = true;
                UnityEngine.Debug.Log("땅을 밝았따 !!!!");
                animator.SetBool("isJumping", false);
            }
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            grounded = false;
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
            
            Mob.mobReset();
            npc1.npcReset();
            npc2.npcReset();
            npc3.npcReset();
            npc4.npcReset();
            GM.stagepoint = 0;

            spriteRenderer.color = new Color(1, 1, 1, 0.4f);
            spriteRenderer.flipY = true;

            Boxcollider.enabled = false;

            PlaySound("die");
            rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        }


        private void PlaySound(string action)
        {
            switch (action)
            {
                case "jump"://
                    sound.clip = audioJump;
                    break;
                case "attack":// 
                    sound.clip = audioAttack;
                    break;
                case "damaged":// 
                    sound.clip = audioDamaged;
                    break;
                case "item":// 
                    sound.clip = audioItem;
                    break;
                case "die":// 
                    sound.clip = audioDie;
                    break;
                case "finish":// 
                    sound.clip = audioFinish;
                    break;
            }
            sound.Play();

        }


    }
}