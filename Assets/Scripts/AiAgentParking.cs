using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAgentParking : MonoBehaviour
{
    public bool Occupied = false;
        
 
    
    public Vector3 GetAgentPosition()
    {
        return transform.position;
    }
}
