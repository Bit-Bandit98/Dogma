using UnityEngine;

public class TravelAgentSkill : MonoBehaviour, IHasSkill
{
    [SerializeField] private TargetSkill TravelSkill = null;
    private SkillSlot Slot = null;
    private Agent agent = null;

    private void Awake()
    {
        Slot = GetComponent<SkillSlot>();
        agent = GetComponent<Agent>();
        
        
    }

    private void Start()
    {
        if (agent.GetAgentOfIdeology().GetStats().InstantTravel) TravelSkill.SetTurnsToComplete(0);
    }
    public void CheckIsRightTarget()
    {
        
        if (TravelSkill.GetTarget() == null) return;
        ITargetable TempIT = TravelSkill.GetTarget().GetComponentInChildren<ITargetable>();
        if (TempIT == null) return;
        GameObject TempOBJ = TempIT.GetOBJIfCorrectType(TravelSkill.GetTargetMode());

        if (TempOBJ != null)
        {
            Slot.SetCurrentSkillInProgress(TravelSkill);
            
            
        }
   
    }
    public void Travel()
    {
        InfluenceSystem IS = TravelSkill.GetTarget().GetComponentInChildren<InfluenceSystem>();
        if (IS.GetOccupied()) return;
       agent.SetCurrentLocation(TravelSkill.GetTarget().GetComponentInChildren<InfluenceSystem>(), false);
    }

    public Skill Getskill()
    {
        return TravelSkill;
    }

    public SkillSlot GetSkillSlot()
    {
        return Slot;
    }
}