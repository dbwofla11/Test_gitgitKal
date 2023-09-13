using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Stage2;
public class Door : MonoBehaviour
{
    [SerializeField] float destroyTime = 0.1f;
    public GameManager GM;
    private bool isOpenDoor;

    private void Update()
    {
        isOpenDoor = GM.getIsOpened();
        if (isOpenDoor)
        {
            Destroy(gameObject, destroyTime);
        }        
    }

}
