using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkillCard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI SkillName, SkillDescription, SkillTurns;
    [SerializeField] private Image SkillIcon;
    [SerializeField] private Button CardButton;
    public void Initialize(Skill GivenSkill, SkillSlot GivenSlot)
    {
        SkillName.text = GivenSkill.GetDetails().GetName();
        SkillDescription.text = GivenSkill.GetDetails().GetDescription();
        SkillTurns.text = GivenSkill.GetTurnsToComplete().ToString();
        SkillIcon.sprite = GivenSkill.GetIcon();

        CardButton.onClick.RemoveAllListeners();
        if(GivenSkill is TargetSkill) CardButton.onClick.AddListener((() => {
            TargetSkill TempTS = GivenSkill as TargetSkill;
            Targeter.EnterTargetMode(TempTS.GetTargetMode());
            Targeter.TargetPayload += TempTS.SetTarget;
            Targeter.TargetPayload += TempTS.ActivateOnTargetAquired;
            
            }));
        else CardButton.onClick.AddListener((() => { GivenSlot.SetCurrentSkillInProgress(GivenSkill);}));

        
       
    }

    public void AddTurnOff(SkillBarUI SBUI)
    {
        CardButton.onClick.AddListener((() => { SBUI.CloseActionBar(); }));
    }
}