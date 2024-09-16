using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentFactory : MonoBehaviour
{
    [SerializeField] private GameObject AgentPrefab = null;
    public static AgentFactory Singleton = null;

    private void Awake()
    {
        Singleton = this;
    }
    public  void CreateAgent(IIdea GivenIdea, InfluenceSystem GivenIS)
    {
        GameObject TempAgent = Instantiate(AgentPrefab);
        TempAgent.GetComponent<Agent>().Initialize(GivenIdea, GivenIS, false);
    }
}
