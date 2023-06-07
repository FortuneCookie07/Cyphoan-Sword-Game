using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordStats : MonoBehaviour
{
    public string swordName;
    public int damage;
    public float attackSpeed;
    public pElement primaryElement;
    public sElement secondaryElement;
    public int swordCost; 
}

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