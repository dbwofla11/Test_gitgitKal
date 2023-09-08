using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class NpcAI : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onTriggerEnter2D(Collider2D collision)
    {       
        if(collision.gameObject.tag == "Player")
        {
            target.SetActive(false);
        }
    }

    public void npcReset()
    {
        target.SetActive(true);
    }
}
