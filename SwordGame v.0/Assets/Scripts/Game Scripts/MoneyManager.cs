using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance; // Singleton instance
    
    public int startingMoney = 100; // Initial amount of money
    
    private int currentMoney; // Current amount of money

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

    private void Start()
    {
        currentMoney = startingMoney;
    }

    public int GetCurrentMoney()
    {
        return currentMoney;
    }

    public void AddMoney(int amount)
    {
        currentMoney += amount;
    }

    public void SubtractMoney(int amount)
    {
        currentMoney -= amount;
    }
}
