using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    [SerializeField] float destroyTime = 0.1f;
    Rigidbody2D rigid;

     
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("점프를 먹었다 트리거");
            ItemSpawn.Instance.StartCoroutine("SpawnDoubleJump", new Vector2(transform.position.x, transform.position.y));

            Destroy(gameObject, destroyTime);
        }
    }



}

