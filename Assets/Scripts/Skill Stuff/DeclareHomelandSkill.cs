using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeclareHomelandSkill : MonoBehaviour, IHasSkill
{
    [SerializeField] private Skill DHS = null;
    private SkillSlot Slot = null;
    private InfluenceSystem IS = null;
    private GameStatus GS = null;
    public static bool IsAvailable = true;
    private void Awake()
    {
        Slot = gameObject.transform.root.GetComponentInChildren<SkillSlot>();
        IS = gameObject.transform.root.GetComponentInChildren<InfluenceSystem>();
        GS = FindObjectOfType<GameStatus>();
        if (GS.StateOfTheGame == GameStatus.GameState.PreGame) IsAvailable = true;
        
    }

    public void SetShine(bool Condition)
    {
        ButtonShine BS = FindObjectOfType<ButtonShine>(true);
        if(BS != null)
        {
            if (Condition) BS.BeginShine();
            else BS.CancelShine();
        }
    }
    public void DeclareHomeland()
    {
        
        IS.InfluenceTheSystem(PlayerList.HumanPlayer.GetPlayerIdeology(), 1f);
        NextStage();

    }

    public void SetGlobalAvailability(bool Condition)
    {
        IsAvailable = Condition;
        DHS.Available = Condition;
    }
    private void NextStage()
    {
        GS.AdvanceState();
    }
    
    
    public Skill Getskill() {
        DHS.Available = IsAvailable;
        return DHS; }
    public SkillSlot GetSkillSlot() { return Slot; }
}