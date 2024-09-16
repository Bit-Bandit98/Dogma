using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryChangeChecker : MonoBehaviour
{
    private SkillSlot SS = null;
   [SerializeField] private InfluenceSystem IS = null;
    private IIdea CurrentIdea = null;
    private void Awake()
    {
        SS = GetComponent<SkillSlot>();
        IS.GetListOfIdeologies().LocalOnNewKing += CheckIfChanged;
    }

    private bool CheckIfNewIdea()
    {
        IIdea TempIdea = CurrentIdea;
        CurrentIdea = IS.GetTopIdeology();
        if (CurrentIdea == TempIdea) return false;
        else return true;
    }
    private void CheckIfChanged()
    {
        if (CheckIfNewIdea())
        {
            if (SS.GetTurnsLeft() <= 0) return;
            SS.CancelSkill();
        }
    }
}
