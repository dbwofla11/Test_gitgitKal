using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


using Stage2;

namespace Stage2
{
    public class GameManager : MonoBehaviour
    {

        public int totalpoint;
        public int stagepoint;
        public int stageIndex;
        public int stageTime;

        public int hp;
        public int playerJumpCnt;

        public bool IsTraped;
        public bool IsKeyTraped;
        public bool IsOpen;

        public PlayerMove player;


        public Image[] UIhp;
        public Text UIpoint;
        public GameObject UIrestartBtn;
        private void Start()
        {
            hp = 3;
            playerJumpCnt = 1;
            stagepoint = 0;

            IsTraped = false;
            IsKeyTraped = false;
            IsOpen = false;
        }

        private void Update()
        {
            UIpoint.text = "Score : " + stagepoint.ToString();
        }


        public void NextStage()
        {
            stageIndex++;

            totalpoint += stagepoint;
            stagepoint = 0;



        }

        public void HPDown()
        {
            if (hp >= 1)
            {
                --hp;
                UIhp[hp].color = new Color(1, 0, 0, 0.4f);
            }
            if (hp <= 0)
            {
                player.OnDie();
                UIrestartBtn.SetActive(true);
            }
        }

        public void JumpCntUp()
        {
            playerJumpCnt++;
        }
        public void jumpCntInit()
        {
            playerJumpCnt = 1;
        }
        public bool getIsTraped()
        {
            return IsTraped;
        }
        public bool getIsKeyTraped()
        {
            return IsKeyTraped;
        }

        public bool getIsOpened()
        {
            return IsOpen;
        }

        public void NextSceneWithString()
        {
            // 문자열 이용해서 씬 전환w
            SceneManager.LoadScene("Scenes/Stage3"); // OK
        }

        // Update is called once per frame
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                HPDown();
                collision.attachedRigidbody.velocity = Vector2.zero;
                collision.transform.position = new Vector3(-75, 0, -1);
                jumpCntInit();

            }
        }
    }
}