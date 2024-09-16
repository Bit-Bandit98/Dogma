using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInfluenceInject : MonoBehaviour, IClickable
{
    public void OnClick()
    {
        GetComponent<InfluenceSystem>().InfluenceTheSystem(PlayerList.HumanPlayer.GetPlayerIdeology(), 0.10f);

    }
}
