using UnityEngine;

public class TurnMaster : MonoBehaviour
{
    private int CurrentTurn = 0;
    public delegate void DNextTurn();
    public static event DNextTurn BeforeOnNextTurn;
    public static event DNextTurn OnNextTurn;
    public void NextTurn()
    {
        CurrentTurn++;
        InvokeOnNextTurn();
    }
    private void OnDisable()
    {
        BeforeOnNextTurn = null;
        OnNextTurn = null;
    }
    private void InvokeOnNextTurn()
    {
        if (BeforeOnNextTurn != null) BeforeOnNextTurn.Invoke();
        if (OnNextTurn != null) OnNextTurn.Invoke();
    }

    public int GetCurrentTurn() { return CurrentTurn; }

}