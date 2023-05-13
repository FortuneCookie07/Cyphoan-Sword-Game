using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Sword
{
    public string name;
    public int damage;
    public pElement primaryElem; 
    public sElement secondaryElem;
    public Dictionary<string,float> sizeCooldowns;
    public GameObject prefab;

    public Sword(string _name, int _damage, pElement _primaryElem, sElement _secondaryElem, Dictionary<string,float> _sizeCooldowns,  GameObject _prefab)
    {
        name = _name;
        damage = _damage;
        primaryElem = _primaryElem;
        secondaryElem = _secondaryElem;
        sizeCooldowns = _sizeCooldowns;
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

public class swordStruct : MonoBehaviour
{
    public static Dictionary<string, int> sizeCooldowns_d;

    // Start is called before the first frame update
    void Start()
    {
        sizeCooldowns_d = new Dictionary<string, int>
        {
            { "Small", 1 },
            { "Medium", 2 },
            { "Large", 3 }
        };
    }
}
