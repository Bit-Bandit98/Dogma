using UnityEngine;

public class SkillSlot : MonoBehaviour
{
    private Skill CurrentSkillInProgress = null, LastFinishedSkill = null;
    private int TurnsLeft = 5;

    public delegate void Updated();
    public event Updated OnSlotUpdate;

    private void OnEnable()
    {
        TurnMaster.OnNextTurn += NextTurn;
    }

    private void OnDisable()
    {
        TurnMaster.OnNextTurn -= NextTurn;
    }

    private void NextTurn()
    {
        
        if (CurrentSkillInProgress == null) return;
        
        TurnsLeft--;
        if (TurnsLeft <= 0)
        {
            CurrentSkillInProgress.ActivateSkill();
            LastFinishedSkill = CurrentSkillInProgress;
            CurrentSkillInProgress = null;
        }
        InvokeOnSlotUpdate();
    }

    public void CancelSkill()
    {
        if (CurrentSkillInProgress != null)
        {
            CurrentSkillInProgress.ActivateOnActionCancel();
            print("CANCELED!");
            CurrentSkillInProgress = null;
            InvokeOnSlotUpdate();
        }
        

    }

    public void SetCurrentSkillInProgress(Skill GivenSkill)
    {
        CancelSkill();
        CurrentSkillInProgress = GivenSkill;
        if (CurrentSkillInProgress == null) return;
        GivenSkill.ActivateBeforeSkillAction();
        TurnsLeft = GivenSkill.GetTurnsToComplete();
        if (GivenSkill is TargetSkill)
        {
            TargetSkill TtempTS = GivenSkill as TargetSkill;
            TtempTS.SetTarget();

        }
        if (TurnsLeft <= 0)
        {
            CurrentSkillInProgress.ActivateSkill();
            LastFinishedSkill = CurrentSkillInProgress;
            InvokeOnSlotUpdate();
            CurrentSkillInProgress = null;
        }

        InvokeOnSlotUpdate();
    }

    private void InvokeOnSlotUpdate() { if (OnSlotUpdate != null) OnSlotUpdate(); }
    public bool GetIsInProgress() { return CurrentSkillInProgress != null; }
    public int GetTurnsLeft() { return TurnsLeft; }
    public Skill GetSkillInProgress() { return CurrentSkillInProgress; }
    public Skill GetLastFinishedSkill() { return LastFinishedSkill; }
}