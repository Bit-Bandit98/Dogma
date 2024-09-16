using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private GameStatus GS = null;

    private void Awake()
    {
        GS = FindObjectOfType<GameStatus>();
    }
    private void OnEnable()
    {
        GameStatus.OnStatusUpdate += CheckIfOver;
    }

    private void OnDisable()
    {
        GameStatus.OnStatusUpdate -= CheckIfOver;
    }

    private void CheckIfOver()
    {
        if(GS.StateOfTheGame == GameStatus.GameState.Lose || GS.StateOfTheGame == GameStatus.GameState.Win)
        {
            OpenEndingWindow();
        }
    }

    private void OpenEndingWindow()
    {

    }
}