using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace machine_chemical{
public class ItemSpawn : MonoBehaviour
{
    public static ItemSpawn Instance = null;
    [SerializeField] GameObject platform;
    [SerializeField] GameObject doubleJump;
    [SerializeField] float posX1, posX2 , jumpPosX3 ,posY , jumpPosY ;
    [SerializeField] float spawnTime = 2f;

    void Start()
    {
        if ( Instance == null)
        {
            Instance = this;
        }
        else if ( Instance != this)
        {
            Destroy(gameObject);
        }

        Instantiate(platform, new Vector2(posX1, posY), platform.transform.rotation);
        Instantiate(platform, new Vector2(posX2, posY), platform.transform.rotation);

        Instantiate(doubleJump, new Vector2(jumpPosX3, jumpPosY), doubleJump.transform.rotation);
    }

    IEnumerator SpawnPlatform(Vector2 spawnPos)
    {
        yield return new WaitForSeconds(spawnTime);
        Instantiate(platform, spawnPos, platform.transform.rotation);
        Instantiate(doubleJump, spawnPos, doubleJump.transform.rotation);
    }
    

}
}
