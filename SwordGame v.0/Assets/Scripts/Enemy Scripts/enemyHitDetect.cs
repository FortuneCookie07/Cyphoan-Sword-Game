 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHitDetect : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("sword_t"))
        {
            //Get the enemyHealth class from the enemyHealth script
            enemyHealth eHealth = gameObject.GetComponent<enemyHealth>(); 
            //Handle Damage and any other damage things
            if(eHealth != null)
            {
                Debug.Log("Object Exists"); 
                eHealth.TakeDamage(SwordManager.playerSword.damage);
            }
            else
            {
                Debug.Log("No Object");
            }
            Debug.Log("Sword Collision And Damage");
        }
    }
}
