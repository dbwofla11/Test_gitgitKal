using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Stage2;
public class DoorKey : MonoBehaviour
{

    public GameManager GM;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (!GM.IsOpen)
            {
                GM.IsOpen = true;
                GM.stagepoint += 1000;
            }
            
        }
    }
}
