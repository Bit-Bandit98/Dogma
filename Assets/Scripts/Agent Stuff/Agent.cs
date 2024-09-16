using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    private IIdea AgentOfIdeology = null;
    private InfluenceSystem CurrentLocation = null;
    [SerializeField] private GameObject AgentObj, HelicopterObj;
    private bool IsAI = false;
    private AiAgentParking AIParkedSpot = null;
    [SerializeField] private GameObject AgentMesh = null;
    public void Initialize(IIdea GivenIdea, InfluenceSystem StartingLocation, bool IsItAI = false)
    {
        IsAI = IsItAI;
       SetCurrentLocation(StartingLocation, IsItAI, true);
       SetAgentIdeology(GivenIdea);
        GetComponentInChildren<Renderer>().material.SetColor("_Color", GivenIdea.GetColours().GetMainColour() * 0.8f);
        Renderer[] TempRend = HelicopterObj.GetComponentsInChildren<Renderer>(true);
        
        foreach(Renderer Rend in TempRend)
        {
            
            Rend.material.SetColor("_Color", GivenIdea.GetColours().GetMainColour());
        }
    }

    public void SetCurrentLocation(InfluenceSystem NewLocation,bool IsAI, bool SkipAnim = false)
    {
        Vector3 FinalPosition;
        if (NewLocation == CurrentLocation) return;
        if (!IsAI) { 
            if(CurrentLocation != null) CurrentLocation.SetOccupied(false);
            CurrentLocation = NewLocation;
            if (CurrentLocation == null) return;
            CurrentLocation.SetOccupied(true);
            FinalPosition = CurrentLocation.GetAgentPoint().position;
        }
        else
        {
            if (AIParkedSpot != null) AIParkedSpot.Occupied = false;
            if( CurrentLocation != null) CurrentLocation.GetDiscoverState().OnDiscovery -= TurnOnAgentMesh;
            CurrentLocation = NewLocation;

            if (CurrentLocation == null) return;
            AiAgentParking AIAP = CurrentLocation.GetAiAgentParking();
            FinalPosition = AIAP.GetAgentPosition();
            AIAP.Occupied = true;
            AIParkedSpot = AIAP;
            if (!CurrentLocation.GetDiscoverState().GetIsDiscovered()) AgentMesh.gameObject.SetActive(false);
            else AgentMesh.gameObject.SetActive(true);

            CurrentLocation.GetDiscoverState().OnDiscovery += TurnOnAgentMesh;

        }
        if (SkipAnim)
        {
            transform.position = FinalPosition;
        }
        else
        {
            StartCoroutine(TravelAnimation(FinalPosition));
        }

    }
    private IEnumerator TravelAnimation(Vector3 TargetPosition)
    {
        float Timer = 0f;
        Vector3 CurrentPos = transform.position;
        AgentObj.SetActive(false);
        HelicopterObj.SetActive(true);
        HelicopterObj.transform.LookAt(TargetPosition, Vector3.up);
        while ( Timer < 1f)
        {
            //transform.position = Vector3.Lerp(CurrentPos, TargetPosition, Timer);  
            transform.position = QuadBezier(CurrentPos, TargetPosition, Vector3.Lerp(CurrentPos, TargetPosition, 0.5f) + Vector3.up*3, Timer * Timer *(3f-2f*Timer));
            Timer += Time.deltaTime / 2;
           
            yield return null;
        }
        transform.position = TargetPosition;
        AgentObj.SetActive(true);
        HelicopterObj.SetActive(false);
    }

    public static Vector3 QuadBezier(Vector3 From, Vector3 To, Vector3 Handle, float Time)
    {
        Vector3 L1 = Vector3.Lerp(From, To, Time);
        Vector3 L2 = Vector3.Lerp(Handle, To, Time);
        return Vector3.Lerp(L1, L2, Time);
    }
    public InfluenceSystem GetCurrentLocation() { return CurrentLocation; }
    public IIdea GetAgentOfIdeology() { return AgentOfIdeology; }
    public void SetAgentIdeology(IIdea NewIdea)
    {
        AgentOfIdeology = NewIdea;
    }

    private void TurnOnAgentMesh() { AgentMesh.SetActive(true); }
}