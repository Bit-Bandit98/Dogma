using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerCardSettings : MonoBehaviour
{
    private string PlayerName = "Player";
    private IIdea PlayerIdea = null;
    private int Dominations = 0, TotalAreas = 0;
    private GameStatus GS = null;
    public delegate void Updated();
    public Updated OnUpdate;


    private void Start()
    {
        Player Human = PlayerList.HumanPlayer;
        PlayerName = Human.GetName();
        PlayerIdea = Human.GetPlayerIdeology();
        TotalAreas = DominantionStatus.GetNumberOfInfluenceSystems();
        GS = FindObjectOfType<GameStatus>();
        UpdateDominationProgress();
        ListOfProminentIdeologies.OnNewKing += UpdateDominationProgress;

    }

    private void OnDisable()
    {
        ListOfProminentIdeologies.OnNewKing -= UpdateDominationProgress;
    }

    private void UpdateDominationProgress()
    {
        Dominations = DominantionStatus.GetDominatedPlaces(PlayerIdea);
        //CheckIfFinished();
        Invoke("CheckIfFinished", 0.5f);
        Invoke("InvokeOnUpdate", 0.5f);
    }

    private void CheckIfFinished()
    {
        if (GS.StateOfTheGame != GameStatus.GameState.Game) return;
        if (Dominations <= 0) GS.FinishGame(false);
        if (Dominations >= TotalAreas) GS.FinishGame(true);
    }

    public string GetPlayerName() { return PlayerName; }
    public void SetPlayerName(string NewName) { PlayerName = NewName; }
    public IIdea GetPlayerIdeology() { return PlayerIdea; }
    public void SetPlayerIdeology(IIdea NewIdea) { PlayerIdea = NewIdea; }
    public int GetDominations() { return Dominations; }
    public int GetAreas() { return TotalAreas; }
    public void InvokeOnUpdate() { if (OnUpdate != null) OnUpdate.Invoke(); }
}