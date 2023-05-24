using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  
    public GameState State; 
    
    public static event Action<GameState> OnGameStateChanged; 
    
    private void Awake()
    {
        Instance = this; 
    }
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateGameState(GameState.Menu); 
    }
 
    public void UpdateGameState(GameState newState){
        State = newState; 

        switch (newState){
            case GameState.Menu:
                // Code/Functions for handling Menu state
                break;
            case GameState.PVE:
                // Code/Functions for handling PVE state
                break;
            case GameState.Victory:
                // Code/Functions for handling Victory state
                break;
            case GameState.Lose:
                // Code/Functions for handling Lose state
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState); 
    }
}

public enum GameState{
    Menu, 
    PVE, 
    Victory,
    Lose
}