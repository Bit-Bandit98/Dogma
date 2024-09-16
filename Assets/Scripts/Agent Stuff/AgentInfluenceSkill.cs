using UnityEngine;
using System;
public class AgentInfluenceSkill : MonoBehaviour, IHasSkill
{
    [SerializeField] private Skill InfluenceSkill = null;
    private SkillSlot Slot = null;
    private Agent agent = null;

    private void Awake()
    {
        Slot = GetComponent<SkillSlot>();
        agent = GetComponent<Agent>();
    }

    private void Start()
    {
        //int TempValue = (int)Math.Floor(InfluenceSkill.GetTurnsToComplete() / agent.GetAgentOfIdeology().GetStats().InfluenceMultiplyer);
        InfluenceSkill.SetTurnsToComplete(InfluenceSkill.GetTurnsToComplete());
    }

    public void Influence(float Percentage)
    {
        IIdea TempAgentIdea = agent.GetAgentOfIdeology();
        agent.GetCurrentLocation().InfluenceTheSystem(TempAgentIdea, Percentage *agent.GetAgentOfIdeology().GetStats().InfluenceMultiplyer);
    }

    public Skill Getskill()
    {
        InfluenceSkill.Available = SKillConditional();
        return InfluenceSkill;
    }

    private bool SKillConditional()
    {
        if (agent.GetCurrentLocation().GetDiscoverState().GetIsDiscovered()) {
            if (!Slot.GetIsInProgress()) return true;
            if (Slot.GetSkillInProgress().GetDetails().GetName() != InfluenceSkill.GetDetails().GetName())
            {
                return true;
            }
        }
        return false;
    }

    public SkillSlot GetSkillSlot()
    {
        return Slot;
    }
}