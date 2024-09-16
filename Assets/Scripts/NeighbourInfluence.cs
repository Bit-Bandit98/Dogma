using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class NeighbourInfluence : MonoBehaviour
{
    [SerializeField] private int TurnsToInfluence = 5;
    [SerializeField] private float NeighbourInfluenceValue = 0.05f;
    private int TurnsToInfluenceModify = 5;
    private Country[] Neighbours = null;
    private InfluenceSystem HomeIS = null;

    private void Awake()
    {
        Neighbours = gameObject.transform.root.GetComponentInChildren<Country>().GetNeighbours();
        HomeIS = gameObject.transform.root.GetComponentInChildren<InfluenceSystem>();
        TurnsToInfluenceModify = TurnsToInfluence;
    }
    private void OnEnable()
    {
        TurnMaster.OnNextTurn += NextTurn;
    }
    private void OnDisable()
    {
        TurnMaster.OnNextTurn -= NextTurn;
    }
    private void InfluenceNeighbours()
    {
        IIdea TempIdea = HomeIS.GetTopIdeology();
        float Value = NeighbourInfluenceValue * TempIdea.GetStats().NeighbouringInfluenceMultiplyer;
        InfluenceSystem TempIS;
        foreach(Country Coun in Neighbours)
        {
            TempIS = Coun.gameObject.transform.root.GetComponentInChildren<InfluenceSystem>();
            TempIS.InfluenceTheSystem(TempIdea, Value);
            if(TempIS.GetTopIdeology().GetDetails().GetName() == PlayerSettings.PlayerIdea.GetDetails().GetName())
            {
                Coun.GetDiscoverState().Discover();
                TempIS.InvokeOnUpdate();
            }
            
        }  
    }

    private void NextTurn()
    {
        if(!ConditionsMet())
        {
            TurnsToInfluenceModify = TurnsToInfluence;
            return;
        }
        TurnsToInfluenceModify--;
        if(TurnsToInfluenceModify <= 0)
        {
            InfluenceNeighbours();
            TurnsToInfluenceModify = TurnsToInfluence;
        }
    }

    private bool ConditionsMet()
    {
        if (HomeIS.GetTopIdeology().GetDetails().GetName() == PredefinedIdeologies.Singleton.GetApathetic().GetDetails().GetName()) return false;
        return true;
    }
}