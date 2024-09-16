using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSkillCheck : MonoBehaviour
{
    [SerializeField] private SkillSlot SS = null;

    private void OnEnable()
    {
        SS.OnSlotUpdate += Dosomething;
    }

    private void OnDisable()
    {
        SS.OnSlotUpdate -= Dosomething;
    }
    private void Dosomething()
    {
        if (TutorialSettings.TutorialFinished) return;
        ButtonShine BS = FindObjectOfType<ButtonShine>();
        TutorialInfo TInfo = FindObjectOfType<TutorialBlob>().GetCurrentTutorial();
        if (TInfo == null) return;
        if (TInfo.GetForceUseSkillID() == Skill.SkillTypes.None) return;
        if (TInfo == null) return;
 
            if (SS.GetSkillInProgress() == null) return;
            if(CheckConditions(TInfo)) {
         
                BS.BeginShine();
                BS.SetEnabledButton(true);
            TutorialSettings.DisableSkills = true;
            } 
        else
            {
                BS.CancelShine();
                BS.SetEnabledButton(false);
                TutorialSettings.DisableSkills = false;
            }
    }

    public bool CheckConditions(TutorialInfo TInfo)
    {
        if(SS.GetSkillInProgress() != null)
        {
            if (SS.GetSkillInProgress().Type == TInfo.GetForceUseSkillID()) return true;
        }
        if (TInfo.GetCanBeLastFinished())
        {
            if (SS.GetLastFinishedSkill() == null) return false;
            if (SS.GetLastFinishedSkill().Type == TInfo.GetForceUseSkillID()) return true;
        }
        return false;
    }
}