using UnityEngine;

[System.Serializable]
public class TutorialInfo
{
    [SerializeField, TextArea] private string Message = "Default";
    [SerializeField] private int TurnShown = 0;
    [SerializeField] private bool DisableNextTurn = false;
    [SerializeField] private Skill.SkillTypes ForceUseSkill;
    [SerializeField] private bool CanBeLastFinished = false;

    public bool CanEndTutorial = false;     
    public bool GetDisableNextTurn() { return DisableNextTurn; }
    public string GetMessage() { return Message; }
    public int GetTurnShown() { return TurnShown; }
    public Skill.SkillTypes GetForceUseSkillID() { return ForceUseSkill; }
    public bool GetCanBeLastFinished()
    {
        return CanBeLastFinished;
    }
}
