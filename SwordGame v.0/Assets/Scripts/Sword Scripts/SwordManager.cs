using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Sword
{
    public string name;
    public int damage;
    public pElement primaryElem; 
    public sElement secondaryElem;
    //"Small", "Medium", or "Large"
    public string size;
    public GameObject prefab;

    public Sword(string _name, int _damage, pElement _primaryElem, sElement _secondaryElem, string _size,  GameObject _prefab)
    {
        name = _name;
        damage = _damage;
        primaryElem = _primaryElem;
        secondaryElem = _secondaryElem;
        size = _size;
        prefab = _prefab;
    }
}

//This is where you start adding elements two your sword
public enum pElement
{
    Fire,
    Water, 
    Earth
}

public enum sElement
{
    None,
    Light,
    Dark, 
    Steel
}

public class SwordManager : MonoBehaviour
{
    public static Dictionary<string, int> sizeCooldowns_d;

    //Will serve as the current sword the player has in hand
    public static Sword playerSword; 

    //Will Store all the playable swords into an array
    public GameObject[] swordArr; 

    void Start()
    {
        sizeCooldowns_d = new Dictionary<string, int>
        {
            { "Small", 1 },
            { "Medium", 2 },
            { "Large", 3 }
        };
        playerSword = new Sword("Yone", 10, pElement.Fire, sElement.None, "Medium", GameObject.Find("YoneLeagueSword"));
    }
}
