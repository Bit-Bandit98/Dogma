using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class AiPlayerActions : MonoBehaviour
{
    private Player AiGoon = null;
    private int TurnsTillAction = 10;
    private InfluenceSystem TargettedIS = null;
    private AudioSource AS = null;
    public Agent AIAGENT = null;
    private void InfluenceSomething()
    {
        
        float RandomInfluence = Random.Range(0.25f, 0.40f);
        if (TargettedIS == null) GetRandomTarget();
        TargettedIS.InfluenceTheSystem(AiGoon.GetPlayerIdeology(), RandomInfluence);
       if(TargettedIS.GetDiscoverState().GetIsDiscovered())  AS.Play();
    }

    private void GetRandomTarget()
    {
        List<InfluenceSystem> IS = FindObjectsOfType<InfluenceSystem>().ToList();
        
        IS.RemoveAll((x) => { return x.GetTopIdeology().GetDetails().GetName() == AiGoon.GetPlayerIdeology().GetDetails().GetName(); });
        if (IS.Count <= 0) return;
        int RandomIndex = Random.Range(0, IS.Count);
        if (TargettedIS != null) TargettedIS.EnemyUiInstance.RemoveEnemy(AiGoon.GetPlayerIdeology());
        TargettedIS = IS[RandomIndex];

        TargettedIS.EnemyUiInstance.AddEnemy(AiGoon.GetPlayerIdeology());



        if (!TargettedIS.GetDiscoverState().GetIsDiscovered()) AIAGENT.SetCurrentLocation(TargettedIS, true, false);
        else AIAGENT.SetCurrentLocation(TargettedIS, true);

       
        
    }
    private void NextTurn()
    {
        if (TargettedIS == null)
        {
            
            TurnsTillAction = Random.Range(5, 9);
            GetRandomTarget();
        }else TurnsTillAction--;
        
        if (TurnsTillAction <= 0)
        {
            InfluenceSomething();
            RandomizeTurnsTill();
            GetRandomTarget();
        }
    }
    public void Initialise(Player GivenPlayer)
    {
        
        AiGoon = GivenPlayer;
        if (AiGoon == null) return;
        TurnMaster.OnNextTurn += NextTurn;
        AS = GetComponent<AudioSource>();
    }

    public void DeInitilise()
    {
        TurnMaster.OnNextTurn -= NextTurn;
    }
    private void RandomizeTurnsTill()
    {
        TurnsTillAction = Random.Range(1, 3);
    }
    
    public Player GetPlayer()
    {
        return AiGoon;
    }

    public void SetAiAgent(Agent GivenAiAgent)
    {
        AIAGENT = GivenAiAgent;
        if (AIAGENT == null) return;
        AIAGENT.Initialize(AiGoon.GetPlayerIdeology(), TargettedIS, true);
    }
}