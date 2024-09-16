using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaWin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            InfluenceSystem[] TempIS = FindObjectsOfType<InfluenceSystem>();
            foreach(InfluenceSystem IS in TempIS)
            {
                IS.GetDiscoverState().Discover();
                IS.InfluenceTheSystem(PlayerSettings.GetPlayer().GetPlayerIdeology(), 1, false);
            }
        }
    }
}
