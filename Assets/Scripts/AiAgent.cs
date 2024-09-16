using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAgent : MonoBehaviour
{
    private void Start()
    {
        AiPlayerActions[] AIPA = FindObjectsOfType<AiPlayerActions>();
        foreach(AiPlayerActions Ai in AIPA)
        {
            if (Ai.AIAGENT == null)
            {
                
                Ai.SetAiAgent( GetComponent<Agent>());

                break;
            }
        }
    }
}
