using System.Collections.Generic;
using UnityEngine;

public class PlayerList : MonoBehaviour
{
    private Player[] PlayersInGame = null;
    public static Player HumanPlayer;

    private List<AiPlayerActions> Bots = new List<AiPlayerActions>();
    private void Start()
    {
        DontDestroyCheck();
    }


    private void DontDestroyCheck()
    {
        PlayerList[] objs = FindObjectsOfType<PlayerList>();

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void PopulatePlayers()
    {
        foreach(AiPlayerActions bot in Bots)
        {
            bot.DeInitilise();
            Destroy(bot);
        }
       Bots.RemoveAll((x) => { return true;});
        PredefinedIdeologies.Singleton.SetAllNotInUse();
        List<Player> NewPlayers = new List<Player>();
        NewPlayers.Add(CreateHumanPlayer());
        foreach(Player AiPlayer in CreateAIPlayers(3))
        {

            NewPlayers.Add(AiPlayer);
            AiPlayerActions TempAct = gameObject.AddComponent<AiPlayerActions>();
            Bots.Add(TempAct);
            TempAct.Initialise(AiPlayer);
        }
        
        PlayersInGame = NewPlayers.ToArray();
    }
    
    private List<Player> CreateAIPlayers(int NumberOfAI)
    {
        List<Player> AIPlayers = new List<Player>();
        for(int i = 0; i < NumberOfAI; i++)
        {
            AIPlayers.Add(new Player("CPU" + i, PredefinedIdeologies.Singleton.GetRandomIdeology()));
        }
        return AIPlayers;
    }
    public Player CreateHumanPlayer()
    {
        HumanPlayer = PlayerSettings.GetPlayer();
        return HumanPlayer;
    }

    public Player[] GetPlayerList() { return PlayersInGame; }

}