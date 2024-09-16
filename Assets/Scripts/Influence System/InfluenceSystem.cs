using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class InfluenceSystem : MonoBehaviour
{
    private IInfluenceHome<Country> SituatedIn = null;
    private ListOfProminentIdeologies ListOfIdeologies = null;
    [SerializeField] private AgentPoint AgentPoint = null;
    private Discoverability DiscoverState = null;
    private InfluenceParticles IP = null;
    private bool Occupied = false;
    public EnemyUI EnemyUiInstance;
    public IIdea LastInfluencedIdea = null;
    public AiAgentParking[] Parking = null;
    public delegate void Updatable();
    public Updatable OnUpdate;
    private void Awake()
    {
        SituatedIn = gameObject.transform.root.GetComponentInChildren<IInfluenceHome<Country>>();
        ListOfIdeologies = new ListOfProminentIdeologies();
        DiscoverState = gameObject.transform.root.GetComponentInChildren<Discoverability>();
        IP = gameObject.transform.root.GetComponentInChildren<InfluenceParticles>();
        DiscoverState.OnDiscovery += InvokeOnUpdate;
        DiscoverState.OnDiscovery += EnemyUiInstance.TurnOnUI;
    }

    private void Start()
    {
        InfluenceTheSystem(PredefinedIdeologies.Singleton.GetApathetic(), 1f, false);
       
    }

   

    public void InfluenceTheSystem(IIdea GivenIdea, float Percentage, bool ConsoleLog = true)
    {
        IIdea TempBeforeIdea = GetTopIdeology();
        Percentage = (float)Math.Round(Percentage, 2);
        InfluenceTools.Influence(this, GivenIdea, Percentage);
        LastInfluencedIdea = GivenIdea;
        if (DiscoverState.GetIsDiscovered()) {
            IP.PlayParticles(GivenIdea);
            if (ConsoleLog) Console.LogMessage(gameObject.transform.root.GetComponentInChildren<Country>().GetDetails().GetName() + " was just influenced by " + GivenIdea.GetDetails().GetName() + " by " + Percentage*100 +"%.");
        } else
        {
            if (ConsoleLog) Console.LogMessage("An undiscovered country was just influenced!");
        }
        InvokeOnUpdate();
        CheckIfNewKing(TempBeforeIdea);
        
    }

    private void CheckIfNewKing(IIdea TempBeforeIdea)
    {
        if (TempBeforeIdea == null) return;
        if (GetTopIdeology().GetDetails().GetName() != TempBeforeIdea.GetDetails().GetName())
        {
            ListOfIdeologies.InvokeNewKing();
        }
    }

    public IIdea GetTopIdeology()
    {
        if (ListOfIdeologies.GetFollowedIdeologies().Count <= 0) return null;
        return ListOfIdeologies.GetFollowedIdeologies()[0].GetFollowedIdeology();
    }

    public IInfluenceHome<Country> GetSituatedIn() { return SituatedIn; }
    public ListOfProminentIdeologies GetListOfIdeologies() { return ListOfIdeologies; }
    public void InvokeOnUpdate() { if (OnUpdate != null) OnUpdate.Invoke(); }
    public Transform GetAgentPoint() { return AgentPoint.GetAgentSpot(); }
    public Discoverability GetDiscoverState() { return DiscoverState; }
    public bool GetOccupied() { return Occupied; }
    public void SetOccupied(bool Condition) { Occupied = Condition; }

    public AiAgentParking GetAiAgentParking()
    {
        foreach(AiAgentParking Parking in Parking)
        {
            if (Parking.Occupied) continue;
            else return Parking;
        }
        return null;
    }
}