using UnityEngine;

public class SkillGatherer : MonoBehaviour, ISelectable, IClickable
{
    private SkillBarUI ABUI = null;
    [SerializeField] private Country CountryData = null;
    [SerializeField] private Agent AgentData = null;

    private void Awake()
    {
        ABUI = FindObjectOfType<SkillBarUI>(true);
        
    }
    public void OnSelect() { }
    public void OnClick()
    {
        if(CountryData != null) ABUI.OpenActionBar(GetSkills(), CountryData.GetDetails().GetName());
        if(AgentData != null) ABUI.OpenActionBar(GetSkills(), "Agent");
    }

    public void OnDeselect()
    {
        ABUI.CloseActionBar();
    }

    public IHasSkill[] GetSkills() {
        
        IHasSkill[] Skills = GetComponents<IHasSkill>();
        return Skills;
    }

}