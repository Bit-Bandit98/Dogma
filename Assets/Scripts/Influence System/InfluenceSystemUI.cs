using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InfluenceSystemUI : MonoBehaviour
{
   
    [SerializeField] private Image TopIdeology = null;
    [SerializeField] private ParticleSystem StatusUpdate = null;
    private InfluenceSystem ConnectedInfluenceSystem = null;
    private Discoverability ISDiscovery = null;

    private int StatusUpdateCounter = 0;

    private void Awake()
    {
        ConnectedInfluenceSystem = GetComponentInParent<InfluenceSystem>();
        
    }

    private void Start()
    {
        ISDiscovery = ConnectedInfluenceSystem.GetDiscoverState();
        ConnectedInfluenceSystem.OnUpdate += UpdateUI;
        ConnectedInfluenceSystem.OnUpdate += TurnOnParticles;
        ISDiscovery.OnDiscovery += TurnOnParticles;
        ISDiscovery.OnDiscovery += IsDiscovered;
    }
    private void TurnOnParticles()
    {
        if (!ConnectedInfluenceSystem.GetDiscoverState().GetIsDiscovered()) return;
        if (StatusUpdate.isPlaying) TurnOffParticles();
        StatusUpdate.Play();
        StatusUpdate.startColor = ConnectedInfluenceSystem.GetTopIdeology().GetColours().GetMainColour();
        TurnMaster.BeforeOnNextTurn += TurnOffParticles;
    }

    private void TurnOffParticles()
    {
        if (!StatusUpdate.isPlaying) return;
        StatusUpdate.Stop();
        TurnMaster.BeforeOnNextTurn -= TurnOffParticles;
    }
    private void UpdateUI()
    {
        if (ISDiscovery.GetIsDiscovered()) { 
        List<IdeologyicalFollowing> TempList = ConnectedInfluenceSystem.GetListOfIdeologies().GetFollowedIdeologies();
        TopIdeology.sprite = TempList[0].GetFollowedIdeology().GetIcon();
        } 
    }

    private void IsDiscovered()
    {
        if (!ISDiscovery.GetIsDiscovered()) return;
        ISDiscovery.OnDiscovery -= IsDiscovered;
        UpdateUI();
    }

    public void SetStatusUpdateCounter(int Value)
    {
        StatusUpdateCounter = Value;
        if (StatusUpdateCounter < 0) StatusUpdateCounter = 0;
    }
}