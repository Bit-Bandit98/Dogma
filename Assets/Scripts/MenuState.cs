using UnityEngine;
using UnityEngine.Events;

public class MenuState : MonoBehaviour
{

    [SerializeField] private UnityEvent StateEnterActions, StateExitActions;

    public void OnStateEnter()
    {
        InvokeStateEnterActions();
    }
    public void OnStateExit()
    {
        InvokeStateExitActions();
    }

    private void InvokeStateEnterActions() { if (StateEnterActions != null) StateEnterActions.Invoke(); }
    private void InvokeStateExitActions() { if (StateExitActions != null) StateExitActions.Invoke(); }
}
