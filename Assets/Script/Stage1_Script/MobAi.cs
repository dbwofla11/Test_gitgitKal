using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

using Stage1;

public class MobAi : MonoBehaviour
{
    Rigidbody2D rigid;
    public float speed;
    Transform target;
    Animator animator;
    public PlayerMove player;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        if (player.isChasing == true)
        {
            
            transform.position += dir * speed * Time.deltaTime;
        }

    }
    public void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public void mobReset()
    {
        player.isChasing = false;
        transform.position = new Vector2(5, 20);

    }
}
