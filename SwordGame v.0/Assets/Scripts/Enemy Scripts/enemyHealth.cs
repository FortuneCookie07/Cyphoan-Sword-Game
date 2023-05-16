using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int eHealth; 
    // Start is called before the first frame update
    void Start()
    {
        eHealth = 100; 
    }

    // Update is called once per frame
    void Update()
    {
        if (eHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Destroyed Enemy");
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Attack Did: " + damage);
        eHealth -= damage; 
        Debug.Log("Enemy Health: " + eHealth); 
    }
}
