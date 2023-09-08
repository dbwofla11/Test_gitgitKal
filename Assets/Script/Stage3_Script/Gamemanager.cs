using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Stage3;
namespace Stage3
{
    public class Gamemanager : MonoBehaviour
    {
        public int totalpoint;
        public int stagepoint;
        public int stageIndex;
        public int stageTime;

        public int playerJumpCnt;

        public PlayerMove player;


        public Image[] UIhp;
        public Text UIpoint;

        private void Start()
        {
            playerJumpCnt = 1; //  ���� ī��Ʈ 
            stagepoint = 0;

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

        public void JumpCntUp()
        {
            playerJumpCnt++;
        }
        public void jumpCntInit()
        {
            playerJumpCnt = 1;
        }

        public void NextSceneWithString()
        {
            // ���ڿ� �̿��ؼ� �� ��ȯ
            SceneManager.LoadScene("Scenes/Stage4"); // OK
        }



    }
}