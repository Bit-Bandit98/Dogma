using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SkillSlotUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI SkillTitle = null, TurnsLeft = null;
    [SerializeField] private Image SkillIcon = null;
    [SerializeField] private Slider ProgressBar = null;
    [SerializeField] private SkillSlot ConnectedSlot = null;

    private void Awake()
    {
        
        ConnectedSlot.OnSlotUpdate += UpdateUI;
        UpdateUI();
    }


    private void UpdateUI()
    {
        if (ConnectedSlot.GetIsInProgress())
        {
            Skill TempSkill = ConnectedSlot.GetSkillInProgress();
            SkillTitle.text = TempSkill.GetDetails().GetName();
            TurnsLeft.text = "Turns Left: " +ConnectedSlot.GetTurnsLeft();
            SkillIcon.sprite = TempSkill.GetIcon();
            ProgressBar.value = 1 -((float)ConnectedSlot.GetTurnsLeft() / (float)TempSkill.GetTurnsToComplete());
            gameObject.SetActive(true);
        } else
        {
            gameObject.SetActive(false);
        }
    }

}
