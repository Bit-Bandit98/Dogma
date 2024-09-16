using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CreateAgentSkill : MonoBehaviour, IHasSkill
{
    [SerializeField] private Skill CAS = null;
    private SkillSlot Slot = null;
    private InfluenceSystem IS = null;
    private IIdea CachedIdea = null;
    private int TempTurnsBeginning = 0;
    private static int NumberOfAgents = 0;
    private void Awake()
    {
        NumberOfAgents = 0;
        Slot = gameObject.transform.root.GetComponentInChildren<SkillSlot>();
        IS = gameObject.transform.root.GetComponentInChildren<InfluenceSystem>();

        TempTurnsBeginning = CAS.GetTurnsToComplete();
    }


    private bool AvailabilityCondition()
    {
        if (IS.GetTopIdeology().GetDetails().GetName() != PlayerList.HumanPlayer.GetPlayerIdeology().GetDetails().GetName()) return false;
        if (IS.GetOccupied()) return false;
        if (NumberOfAgents >= 3) return false;
        // if (!TutorialSettings.TutorialFinished) return false;
        if (Slot.GetIsInProgress())
        {
            if (Slot.GetSkillInProgress().GetDetails().GetName() == CAS.GetDetails().GetName()) return false;
        }
        return true;
    }
    public Skill Getskill()
    {
        if(AvailabilityCondition())
        {
                      
            CAS.Available = true;
            int TempValue = (int)Math.Floor(TempTurnsBeginning/ IS.GetTopIdeology().GetStats().CreateAgentMultiplyer);
            CAS.SetTurnsToComplete(TempValue);
            return CAS;
        }
        CAS.Available = false;
        return CAS;
    }

    public void AddAgentCount(int Amount)
    {
        NumberOfAgents += Amount;
    }
    public void RemoveAgentCount(int Amount)
    {
        NumberOfAgents -= Amount;
    }

    public void CacheTheIdea()
    {
        CachedIdea = IS.GetTopIdeology();
    }
    public void CreateAgent()
    {
        if (CachedIdea == null) CacheTheIdea();
        AgentFactory.Singleton.CreateAgent(CachedIdea, IS);
    }

    public SkillSlot GetSkillSlot()
    {
        return Slot;
    }

}
