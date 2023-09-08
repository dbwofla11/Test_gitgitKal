
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace machine_chemical{
    public class GameManager : MonoBehaviour
{

    public int totalpoint;
    public int stagepoint;
    public int stageIndex;
    public int stageTime;

    public int hp;
    // 점프횟수 
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
        
        IsTraped = false;
        IsKeyTraped = false;
        IsOpen = false;
    }

    private void Update()
    {
       //UIpoint.text = "Score : " + stagepoint.ToString();
       UIpoint.text = "Score: " + stagepoint.ToString();
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
            // --hp;
            // UIhp[hp].color = new Color(1, 0, 0, 0.4f);
            --hp;
            if (hp < UIhp.Length) // 유효한 인덱스 범위 내에서만 접근
            {
                UIhp[hp].color = new Color(1, 0, 0, 0.4f);
            }
        }
        if (hp <= 0)
        {
            player.OnDie();
            UIrestartBtn.SetActive(true);
        }
    }

    public void HPUp()
    {
            ++hp;
        if (hp > 3)
            {
                player.OnDie();
                UIrestartBtn.SetActive(true);
            }
            else
            {

                UIhp[hp-1].color = new Color(1, 1, 1, 1f);

            }
    }


    //땅에 닿았을 때 점프 횟수 초기화 
    public void JumpCntUp()
    {
        playerJumpCnt++;
    }
    // 처음 점프 횟수 초기화 
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
  
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.tag == "Player")        {
            HPDown();
            collision.attachedRigidbody.velocity = Vector2.zero;
            collision.transform.position = new Vector3(-75, 0, -1);
            jumpCntInit();

        }
    }


}

}
