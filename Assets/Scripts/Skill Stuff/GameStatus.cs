using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    public enum GameState { PreGame, Game, Win, Lose };
    public GameState StateOfTheGame = GameState.PreGame;

    public delegate void StatusUpdate();
    public static event StatusUpdate OnStatusUpdate;

    private void Awake()
    {
        StateOfTheGame = GameState.PreGame;
    }
    public void AdvanceState()
    {
        StateOfTheGame++;
        InvokeOnStatusUpdate();
    }

    public void FinishGame(bool PlayerWin)
    {
        if (PlayerWin) { StateOfTheGame = GameState.Win; }
        else {StateOfTheGame = GameState.Lose;}
        InvokeOnStatusUpdate();
    }


    private void InvokeOnStatusUpdate()
    {
       if(OnStatusUpdate != null) OnStatusUpdate.Invoke();
    }
    
}