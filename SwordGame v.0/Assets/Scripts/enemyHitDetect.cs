 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHitDetect : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("sword_t"))
        {
            //Handle Damage and any other damage things
            Debug.Log("Sword Collision");
        }
    }
}
