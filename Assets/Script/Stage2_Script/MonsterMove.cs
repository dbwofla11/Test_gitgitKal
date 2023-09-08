using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRender;
    BoxCollider2D Boxcollider;

    public int nextMove;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
        Boxcollider = GetComponent<BoxCollider2D>();
        Invoke("Think", 5);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

        Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 0.3f , rigid.position.y);
        Debug.DrawRay(frontVec , Vector3.down, new Color(0, 1, 0));

        RaycastHit2D rayHit = Physics2D.Raycast( frontVec , Vector3.down, 1, LayerMask.GetMask("Platforms"));
        if (rayHit.collider == null) {
            turn();
        }
    }


    void Think()
    {
        nextMove = Random.Range(-5, 6);
        
        anim.SetInteger("walkSpeed", nextMove);

        if (nextMove != 0)
        {
            spriteRender.flipX = nextMove >= 1;
        }

        Invoke("Think", 2);
    }

    void turn()
    {
        nextMove *= -1;
        spriteRender.flipX = nextMove >= 1;

        CancelInvoke();
        Think();
    }

    // ∏ÛΩ∫≈Õ∞° π‚«˚¿ª∂ß 
    public void OnDamaged()
    {
        spriteRender.color = new Color(1, 1, 1, 0.4f);
        spriteRender.flipY = true;

        Boxcollider.enabled = false;
        rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);

        Invoke("DeActive", 0.5f);
    }

    private void DeActive()
    {
        gameObject.SetActive(false);
    }


}
