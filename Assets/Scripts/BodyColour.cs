using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyColour : MonoBehaviour
{
    [SerializeField] private Renderer Rend = null;
    private InfluenceSystem IS = null;
    private IIdea CurrentIdea = null;
    private void Awake()
    {
        IS = gameObject.transform.root.GetComponentInChildren<InfluenceSystem>();
        
    }

    private void Start()
    {
        IS.GetListOfIdeologies().LocalOnNewKing += SetColourToIdea;
        IS.GetDiscoverState().OnDiscovery += SetColourToIdea;
        IS.OnUpdate += StartBlink;
        
    }

    private void SetColourToIdea()
    {
        
        if (!IS.GetDiscoverState().GetIsDiscovered()) return;
        if (CurrentIdea == null) ;
        else if (CurrentIdea.GetDetails().GetName() == IS.GetTopIdeology().GetDetails().GetName()) return;
        CurrentIdea = IS.GetTopIdeology();
        StopAllCoroutines();
        StartCoroutine(BeginColorChange(CurrentIdea.GetColours().GetMainColour()));
    }
    private void StartBlink()
    {
        if (!IS.GetDiscoverState().GetIsDiscovered()) return;
        if (IS.LastInfluencedIdea.GetDetails().GetName() == IS.GetTopIdeology().GetDetails().GetName()) return;
        StartCoroutine(ColourBlink(IS.LastInfluencedIdea.GetColours().GetMainColour()));
    }
    private IEnumerator BeginColorChange(Color TargetColor)
    {
        float TempTime = 0f;
        Color StartColor = Rend.material.GetColor("_Color");
        Color CurrentColor;
        while(TempTime < 1f)
        {
            CurrentColor = Color.Lerp(StartColor, TargetColor, TempTime);
            foreach (Material GivenMaterial in Rend.materials) { 
            GivenMaterial.SetColor("_Color", CurrentColor);
            }
            TempTime += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator ColourBlink(Color TargetColor) {
        float TempTime = 0f;
        Color StartColor = Rend.material.GetColor("_Color");
        Color CurrentColor;
        while (TempTime < 1f)
        {
            CurrentColor = Color.Lerp(StartColor, TargetColor, TempTime);
            foreach (Material GivenMaterial in Rend.materials)
            {
                GivenMaterial.SetColor("_Color", CurrentColor);
            }
            TempTime += Time.deltaTime *2;
            yield return null;
        }
        while (TempTime > 0f)
        {
            CurrentColor = Color.Lerp(IS.GetTopIdeology().GetColours().GetMainColour(), TargetColor, TempTime);
            foreach (Material GivenMaterial in Rend.materials)
            {
                GivenMaterial.SetColor("_Color", CurrentColor);
            }
            TempTime -= Time.deltaTime *2;
            yield return null;
        }
    }
}
