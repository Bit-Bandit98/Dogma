using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class Skill 
{
    [SerializeField] private NameAndDescription SkillDetails = null;
    [SerializeField] private IconGraphics Iconography = null;
    [SerializeField] private int TurnsToComplete = 5;
    public enum SkillTypes { Discover, Influence, Travel, CreateAgent, DeclareHomeland, None}
    public SkillTypes Type = SkillTypes.None;
    [SerializeField] private UnityEvent BeforeSkillAction = null;
    public bool Available = true;
    [SerializeField] private UnityEvent SkillAction = null;
    [SerializeField] private UnityEvent OnActionCancel = null;
    public void ActivateSkill()
    {
        if (SkillAction != null)
        {
            SkillAction.Invoke();
        }
    }

    public void ActivateBeforeSkillAction()
    {
        if (BeforeSkillAction != null) BeforeSkillAction.Invoke();
    }

    public void ActivateOnActionCancel()
    {
        if (OnActionCancel != null) OnActionCancel.Invoke();
    }
    public int GetTurnsToComplete() { return TurnsToComplete; }
    public void SetTurnsToComplete(int NewValue) { TurnsToComplete = NewValue; }
    public Sprite GetIcon() { return Iconography.GetIcon(); }
    public NameAndDescription GetDetails() { return SkillDetails; }
}