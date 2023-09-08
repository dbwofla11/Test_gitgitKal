using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Stage1
{

    public class GameManager : MonoBehaviour
    {

        public int totalpoint;
        public int stagepoint;
        public int stageIndex;
        public int stageTime;
        public int goastKeyNum;

        public int hp;
        public int playerJumpCnt;

        public PlayerMove player;
        public Image[] UIhp;
        public Text UIpoint;
        public Text UIgoast;
        public GameObject UIrestartBtn;

        private void Start()
        {
            hp = 1;
            playerJumpCnt = 1;

            goastKeyNum = 4;
            stagepoint = 0;
        }

        private void Update()
        {
            UIpoint.text = "Score : " + stagepoint.ToString();
            UIgoast.text = "남은 유령 수 :" + goastKeyNum.ToString();
        }

        public void NextStage()
        {
            stageIndex++;
            totalpoint += stagepoint;
            stagepoint = 0;
        }

        public void NextSceneWithString()
        {
            // 문자열 이용해서 씬 전환
            SceneManager.LoadScene("Scenes/Stage2"); // OK
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
                UnityEngine.Debug.Log("당신은 죽었습니다");
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

        // Update is called once per frame
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                HPDown();
                collision.attachedRigidbody.velocity = Vector2.zero;
                collision.transform.position = new Vector3(-8, 0, 0);
                jumpCntInit();
            }
        }
    }
}