using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Stage2;
public class KeyChasePlayer : MonoBehaviour
{

    public float speed;
    private Transform target;
    public GameManager GM;

    [SerializeField] float destroyTime = 0.03f;
    private bool ismine;


    private void Start()
    {
        speed = 15;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        ismine = GM.getIsKeyTraped();

        if (ismine)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, destroyTime);
    }
}
