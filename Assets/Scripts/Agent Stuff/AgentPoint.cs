using UnityEngine;

[System.Serializable]
public class AgentPoint 
{
    [SerializeField] private Transform AgentSpot = null;
    public Transform GetAgentSpot() { return AgentSpot; }
}