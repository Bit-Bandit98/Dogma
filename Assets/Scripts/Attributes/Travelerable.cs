using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Travelerable : MonoBehaviour, ITargetable
{
    [SerializeField] private Targeter.TargetType TT;
    private bool IsAvailable = true;
    [SerializeField] private Color Highlightcolor;
    [SerializeField] private Renderer Rend = null;
    private Color OriginalColour;
    private void OnEnable()
    {
        Targeter.OnTargetEnter += OnEnterTargeting;
        Targeter.OnTargetExit += OnExitTargeting;
    }

    private void OnDisable()
    {
        Targeter.OnTargetEnter -= OnEnterTargeting;
        Targeter.OnTargetExit -= OnExitTargeting;
    }
    public GameObject GetOBJIfCorrectType(Targeter.TargetType Type)
    {
        if (TT == Type) return gameObject;
        return null;
    }
    public bool CheckIfAvailable()
    {
        return IsAvailable;
    }

    public void OnEnterTargeting()
    {
        if (Targeter.TargetOBJState != TT) return;
        IsAvailable = !gameObject.transform.root.GetComponentInChildren<InfluenceSystem>().GetOccupied();
        OriginalColour = Rend.material.GetColor("_Color");
        if (IsAvailable)
        {
            foreach (Material GivenMaterial in Rend.materials)
            {
                GivenMaterial.SetColor("_Color", Highlightcolor);
            }
            
        }
        
    }

    public void OnExitTargeting()
    {
       InfluenceSystem TempIS = gameObject.transform.root.GetComponentInChildren<InfluenceSystem>();
        Color TempColor;
        if (TempIS.GetDiscoverState().GetIsDiscovered()) {
            TempColor = TempIS.GetTopIdeology().GetColours().GetMainColour();
        } 
        else
        {
            TempColor = OriginalColour;
        }

        foreach(Material GivenMaterial in Rend.materials)
        {
            GivenMaterial.SetColor("_Color", TempColor);
        }
    }
 
}