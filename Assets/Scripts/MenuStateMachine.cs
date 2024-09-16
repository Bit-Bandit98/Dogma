using UnityEngine;

public class MenuStateMachine : MonoBehaviour
{
    private MenuState CurrentState = null;

    public void SetState(MenuState GivenState)
    {
        if (CurrentState != null) CurrentState.OnStateExit();
        CurrentState = GivenState;
        if (CurrentState != null) CurrentState.OnStateEnter();
    }
}