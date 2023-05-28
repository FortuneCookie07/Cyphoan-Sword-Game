using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordManager : MonoBehaviour
{
    public Dictionary<string, int> sizeCooldowns_d;
    public static SwordManager Instance; 
    public static GameObject playerSword;

    //Will Store all the playable swords into an array
    public GameObject[] swordArr; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void swordInit()
    {
        Instance.swordArr[SwordSelect.swordSelection].SetActive(true);
        playerSword = Instance.swordArr[SwordSelect.swordSelection];
    }
}
