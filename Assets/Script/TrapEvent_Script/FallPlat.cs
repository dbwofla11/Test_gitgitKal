using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlat : MonoBehaviour
{
    [SerializeField] float fallTime = 0.5f, destroyTime = 2f;
    Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ItemSpawn.Instance.StartCoroutine("SpawnPlatform", new Vector2(transform.position.x, transform.position.y));
            Invoke("FallPlatform", fallTime);
            Destroy(gameObject, destroyTime);
        }
    }

    private void FallPlatform()
    {
        rigid.isKinematic = false;
    }

}
