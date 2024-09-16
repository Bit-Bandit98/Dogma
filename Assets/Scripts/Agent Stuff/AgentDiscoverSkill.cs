using UnityEngine;
using System;
public class AgentDiscoverSkill : MonoBehaviour, IHasSkill
{
    [SerializeField] private Skill DiscoverSkill = null;
    private SkillSlot Slot = null;
    private Agent agent = null;

    private void Awake()
    {
        Slot = GetComponent<SkillSlot>();
        agent = GetComponent<Agent>();
    }


    private void Start()
    {
        //int TempValue = (int)Math.Floor(DiscoverSkill.GetTurnsToComplete() / agent.GetAgentOfIdeology().GetStats().DiscoveryMultiplyer);
        DiscoverSkill.SetTurnsToComplete(DiscoverSkill.GetTurnsToComplete());
    }

    public void Discover()
    {
        agent.GetCurrentLocation().GetDiscoverState().Discover();
        if (agent.GetAgentOfIdeology().GetStats().DiscoverNeighbours)
        {
            foreach(Country Coun in agent.GetCurrentLocation().GetSituatedIn().GetNeighbours())
            {
                Coun.GetDiscoverState().Discover();
            }
        }
        
    }

    public Skill Getskill()
    {
        if (agent.GetCurrentLocation().GetDiscoverState().GetIsDiscovered()) DiscoverSkill.Available = false;
        else DiscoverSkill.Available = true;
        return DiscoverSkill;
    }

    public SkillSlot GetSkillSlot()
    {
        return Slot;
    }
}